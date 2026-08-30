using CrudApiDemo.Dtos.ClientDtos;
using CrudApiDemo.Dtos.ClientDtos.Mappers;
using CrudApiDemo.Interfaces.IService;
using CrudApiDemo.Models;
using CrudApiDemo.Responses;
using CrudApiDemo.ViewModels;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace CrudApiDemo.Controllers
{
    [Route("api/[controller]")]
    public class ClientsController : BaseApiController
    {
        private readonly ICrudService<Client> service;
        private readonly IClientService clientService;
        private readonly IValidator<CreateClientDto> createValidator;
        private readonly IValidator<UpdateNameDto> nameValidator;
        private readonly IValidator<UpdateEmailDto> emailValidator;
        private readonly IValidator<UpdatePasswordDto> passwordValidator;

        public ClientsController(ICrudService<Client> _service, IClientService _clientService, IValidator<CreateClientDto> _validator
            , IValidator<UpdateNameDto> _nameValidator, IValidator<UpdateEmailDto> _emailValidator, IValidator<UpdatePasswordDto> _passwordValidator
            )
        {
            service = _service;
            clientService = _clientService;
            createValidator = _validator;
            nameValidator = _nameValidator;
            emailValidator = _emailValidator;
            passwordValidator = _passwordValidator;


        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var clients = await service.GetAll();
            return Ok(BaseResponse<List<ClientDto>>.SuccessResponse(clients.ToClientDtoList()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var client = await service.GetById(id);
            if (client is null) return NotFound(BaseResponse<ClientDto>.FailResponse("Invalid client ID.", 404));
            return Ok(BaseResponse<ClientDto>.SuccessResponse(client.ToClientDto(), 200));
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateClientDto dto)
        {
            var invalid = await ValidateAsync(createValidator, dto);
            if (invalid != null) return invalid;

            var newClient = dto.ToClientEntity();
            var success = await service.Add(newClient);

            if (!success) return BadRequest(BaseResponse<ClientDto>.FailResponse("Email already exist.", 400));

            return CreatedAtAction(nameof(GetById), new { id = newClient.Id },
                BaseResponse<ClientDto>.SuccessResponse(newClient.ToClientDto(), 201));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await service.Delete(id);
            return success
                ? Ok(BaseResponse<string>.SuccessResponse("Client deleted successfully."))
                : NotFound(BaseResponse<string>.FailResponse("Invalid client ID.", 404));
        }

        [HttpPatch("{id}/name")]
        public async Task<IActionResult> UpdateName(int id, UpdateNameDto newName)
        {
            var invalid = Validate(nameValidator, newName);
            if (invalid != null) return invalid;

            var success = await clientService.UpdateName(id, newName.NewName);
            return success
                ? Ok(BaseResponse<string>.SuccessResponse($"Client name updated to {newName.NewName}."))
                : NotFound(BaseResponse<string>.FailResponse("Invalid client ID.", 404));
        }

        [HttpPatch("{id}/email")]
        public async Task<IActionResult> UpdateEmail(int id, UpdateEmailDto newEmail)
        {
            var invalid = await ValidateAsync(emailValidator, newEmail);
            if (invalid != null) return invalid;

            var success = await clientService.UpdateEmail(id, newEmail.NewEmail);
            return success
              ? Ok(BaseResponse<string>.SuccessResponse($"Client email updated to {newEmail.NewEmail}."))
              : NotFound(BaseResponse<string>.FailResponse("Invalid client ID, or email already exist.", 404));
        }

        [HttpPatch("{id}/password")]
        public async Task<IActionResult> UpdatePassword(int id, UpdatePasswordDto newPassword)
        {
            var invalid = Validate(passwordValidator, newPassword);
            if (invalid != null) return invalid;

            var success = await clientService.UpdatePassword(id, newPassword.NewPassword);
            return success
              ? Ok(BaseResponse<string>.SuccessResponse("Client password updated."))
              : NotFound(BaseResponse<string>.FailResponse("Invalid client ID .", 404));
        }
        [HttpGet("{id}/details")]
        public async Task<IActionResult> GetDetails(int id)
        {
            var details = await clientService.GetClientDetails(id);

            if (details is null)
                return NotFound(BaseResponse<ClientDetailsViewModel>.FailResponse("Invalid client ID.", 404));

            return Ok(BaseResponse<ClientDetailsViewModel>.SuccessResponse(details));
        }

    }
}
