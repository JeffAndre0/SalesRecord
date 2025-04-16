using MediatR;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using WebApi.Common;
using WebApi.Features.SaleRecord.CreateSaleRecord;
using WebApi.Features.SaleRecords.GetSaleRecord;
using WebApi.Features.SaleRecords.DeleteSaleRecord;
using Application.SaleRecords.CreateSaleRecord;
using Application.SaleRecords.GetSaleRecord;
using Application.SaleRecords.DeleteSaleRecord;
using WebApi.Features.SaleRecords.CreateSaleRecord;
namespace WebApi.Features.SaleRecord;

/// <summary>
/// Controller for managing salerecord operations
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class SaleRecordController : BaseController
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of SaleRecordController
    /// </summary>
    /// <param name="mediator">The mediator instance</param>
    /// <param name="mapper">The AutoMapper instance</param>
    public SaleRecordController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    /// <summary>
    /// Creates a new salerecord
    /// </summary>
    /// <param name="request">The salerecord creation request</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created salerecord details</returns>
    [HttpPost]
    [ProducesResponseType(typeof(ApiResponseWithData<CreateSaleRecordResponse>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateSaleRecord([FromBody] CreateSaleRecordRequest request, CancellationToken cancellationToken)
    {
        var validator = new CreateSaleRecordRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<CreateSaleRecordCommand>(request);
        var response = await _mediator.Send(command, cancellationToken);

        return Created(string.Empty, new ApiResponseWithData<CreateSaleRecordResponse>
        {
            Success = true,
            Message = "SaleRecord created successfully",
            Data = _mapper.Map<CreateSaleRecordResponse>(response)
        });
    }

    /// <summary>
    /// Retrieves a salerecord by their ID
    /// </summary>
    /// <param name="id">The unique identifier of the salerecord</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The salerecord details if found</returns>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ApiResponseWithData<GetSaleRecordResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetSaleRecord([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var request = new GetSaleRecordRequest { Id = id };
        var validator = new GetSaleRecordRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<GetSaleRecordCommand>(request.Id);
        var response = await _mediator.Send(command, cancellationToken);

        return Ok(new ApiResponseWithData<GetSaleRecordResponse>
        {
            Success = true,
            Message = "SaleRecord retrieved successfully",
            Data = _mapper.Map<GetSaleRecordResponse>(response)
        });
    }

    /// <summary>
    /// Deletes a salerecord by their ID
    /// </summary>
    /// <param name="id">The unique identifier of the salerecord to delete</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Success response if the salerecord was deleted</returns>
    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteSaleRecord([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var request = new DeleteSaleRecordRequest { Id = id };
        var validator = new DeleteSaleRecordRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<DeleteSaleRecordCommand>(request.Id);
        await _mediator.Send(command, cancellationToken);

        return Ok(new ApiResponse
        {
            Success = true,
            Message = "SaleRecord deleted successfully"
        });
    }
}
