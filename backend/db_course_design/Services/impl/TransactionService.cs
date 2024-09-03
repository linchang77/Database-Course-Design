using EntityFramework.Models;
using Microsoft.EntityFrameworkCore;
using db_course_design.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using AutoMapper;
using db_course_design.Profiles;
using db_course_design.Common;
using static System.TimeZoneInfo;

namespace db_course_design.Services.impl
{
    public class TransactionService : ITransactionService
    {
        /*--上下文连接数据库--*/
        private readonly ModelContext _context;
        
        public TransactionService(ModelContext context)
        {
            _context = context;
        }

        /*--管理员获取全部交易记录--*/
        public async Task<List<TransactionRecord>> GetAllTransactionAsync()
        {
            return await _context.TransactionRecords.ToListAsync();
        }
        /*--与类别和用户有关的筛选--*/
        public async Task<List<TransactionRecord>> GetFilteredTransactionsAsync(string? category = null, int? userId = null)
        {
            var query = _context.TransactionRecords.AsQueryable();
            // 管理员根据用户Id筛选&用户获取个人全部交易记录
            if (category == null)
                query = query.Where(o => o.UserId == userId);
            // 管理员根据交易类别筛选
            else if (userId == null)
                query = query.Where(o => o.TransactionCategory.Equals(category));
            // 用户根据交易类别筛选
            else
                query = query.Where(o => o.UserId == userId && o.TransactionCategory.Equals(category));

            var Records = await query.ToListAsync();
            return Records;
        }
        /*--根据交易时间筛选--*/
        public async Task<List<TransactionRecord>> GetTransactionByTimeAsync(DateTime? StartDate, DateTime? EndDate, int? userId)
        {
            var query = _context.TransactionRecords.AsQueryable();

            // admin
            if(userId == null)
            {
                query = query.Where(o => o.TransactionTime >= StartDate && o.TransactionTime <= EndDate);
            }
            // user
            else
            {
                query = query.Where(o => o.UserId == userId && o.TransactionTime >= StartDate && o.TransactionTime <= EndDate);
            }

            var Records = await query.ToListAsync();
            return Records;
        }
        /*--流水统计--*/
        public async Task<decimal?> GetTransactionStatsAsync(int userId, int year, int? month = null)
        {
            var query = _context.TransactionRecords.AsQueryable();
            if (month == null)
                query = query.Where(o => o.UserId == userId && o.TransactionTime.HasValue 
                && o.TransactionTime.Value.Year == year);
            else
                query = query.Where(o => o.UserId == userId && o.TransactionTime.HasValue 
                && o.TransactionTime.Value.Year == year
                && o.TransactionTime.Value.Month == month);

            decimal? totalAmount = await query.SumAsync(o => o.Amount);

            return totalAmount;
        }
    }
}
