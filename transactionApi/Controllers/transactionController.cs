using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using transactionApi.Interface;
using transactionApi.Models;
using transactionApi.Helpers;
using MassTransit;
using System;

namespace transactionApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class transactionController : ControllerBase
    {
        private readonly ILogger<transactionController> _logger;
        private readonly ITransaction _transaction;
        private readonly IBus _bus;

        private long UserId => long.Parse(User.Claims.Single(c => c.Type == ClaimTypes.NameIdentifier).Value);

        public transactionController(ILogger<transactionController> logger, ITransaction transaction, IBus bus)
        {
            _logger = logger;
            _transaction = transaction;
            _bus = bus;
        }
        /// <summary>
        ///     Get the state of your  transaction.
        /// </summary>
        /// <returns>The user's Transaction.</returns>
        [Authorize]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<TransactionView>>> GetTransactions()
        {
            _logger.LogInformation(MyLogEvents.GetItem, "All transaction User:{Id}",UserId);

            return Ok(await _transaction.GetTransactions(UserId));
        }
        /// <summary>
        ///     Create transaction.
        /// </summary>
        /// <param name="command">Request body.</param>
        /// <response code="200">If the wallet has been successfully replenished.</response>
        /// <response code="400">If the request body will not pass validation.</response>
        [Authorize]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<TransactionView>> CreateTransaction([FromBody] CreateTransactionCommand command)
        {
            _logger.LogInformation(MyLogEvents.GenerateItems, "Create transaction User:{Id}", UserId);
            command.Id = Guid.NewGuid();
            command.idUser = UserId;
            _bus.Publish<ITransactionCreate>(new { CreateTransactionCommand = command }); 
            return Ok(await _transaction.CreateTransaction(command, UserId));
        }
    }
}