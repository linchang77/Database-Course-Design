using Microsoft.AspNetCore.Mvc;
using db_course_design.Common;
using db_course_design.Services;
using db_course_design.Services.impl;
using db_course_design.DTOs;
using EntityFramework.Models;

namespace db_course_design.Controllers
{
    /*备注：创建交易记录在OrderController支付成功的请求中
     *路由设计
     *api/Transaction/
     *  {role}/
     *      {Id}/               备注：管理员id随便写，用不上
     *          Get             获取交易记录(admin&user)
     *          search/
     *              {userId}    按userId搜索交易记录(admin)
     *          {orderId}/
     *              Get         按订单Id搜索交易记录(admin&user)
     *          category/
     *              {category}/
     *                  Get     按订单类别筛选交易记录(admin&user)
     *          stats/
     *              {year}/
     *                  Get     年度流水统计(user)
     *                  {month}/
     *                      Get 月度流水统计(user)
     */
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService;

        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }
        /*--获取交易记录(admin&user)--*/
        [HttpGet("{role}/{Id}")]
        public async Task<IActionResult> GetTransaction(string role, int Id)
        {
            List<TransactionRecord>? records = null;

            switch (role)
            {
                case "admin":
                    records = await _transactionService.GetAllTransactionAsync();
                    break;

                case "user":
                    records = await _transactionService.GetFilteredTransactionsAsync(userId: Id);
                    break;

                default:
                    return BadRequest(new { Message = "Role must be 'user' or 'admin'." });
            }

            if (records == null || !records.Any())
            {
                return NotFound(new { Message = "No record yet." });
            }

            return Ok(records);
        }

        /*--按userId搜索交易记录(admin)--*/
        [HttpGet("{role}/{Id}/search/{userId}")]
        public async Task<IActionResult> GetTransactionByUser(string role, int Id, int userId)
        {
            if (role.Equals("admin"))
            {
                var records = await _transactionService.GetFilteredTransactionsAsync(userId: userId);
                if (records == null || !records.Any())
                {
                    return NotFound(new { Message = "No record yet." });
                }
                return Ok(records);
            }
            else
                return BadRequest(new { Message = "Role must be 'admin'." });
        }

        /*--按订单类别筛选交易记录(admin&user)--*/
        [HttpGet("{role}/{Id}/category/{category}")]
        public async Task<IActionResult> GetTransactionByCategory(string role, int Id, string category)
        {
            List<TransactionRecord>? records = null;

            switch (role)
            {
                case "admin":
                    records = await _transactionService.GetFilteredTransactionsAsync(category: category);
                    break;

                case "user":
                    records = await _transactionService.GetFilteredTransactionsAsync(category: category, userId: Id);
                    break;

                default:
                    return BadRequest(new { Message = "Role must be 'user' or 'admin'." });
            }

            if (records == null || !records.Any())
            {
                return NotFound(new { Message = "No record yet." });
            }

            return Ok(records);
        }

        /*--年度流水统计(user)--*/
        [HttpGet("{role}/{Id}/stats/{year}")]
        public async Task<IActionResult> GetYearStats(string role, int Id, int year)
        {
            var stats = await _transactionService.GetTransactionStatsAsync(Id, year);
            return Ok(stats);
        }

        /*--月度流水统计(user)--*/
        [HttpGet("{role}/{Id}/stats/{year}/{month}")]
        public async Task<IActionResult> GetMonthStats(string role, int Id, int year, int month)
        {
            var stats = await _transactionService.GetTransactionStatsAsync(Id, year, month);
            return Ok(stats);
        }
    }
}
