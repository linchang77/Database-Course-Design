using AutoMapper;
using db_course_design.DTOs;
using EntityFramework.Models;

namespace db_course_design.Services
{
    public interface ITransactionService
    {
        // 映射器
        IMapper _mapper { get; }
        // 管理员获取全部交易记录
        Task<List<TransactionRecord>> GetAllTransactionAsync();
        // 与类别和用户有关的筛选
        Task<List<TransactionRecord>> GetFilteredTransactionsAsync(string? category = null, int? userId = null);


        // 流水统计
        Task<decimal?> GetTransactionStatsAsync(int userId, int year, int? month = null);
    }
}
