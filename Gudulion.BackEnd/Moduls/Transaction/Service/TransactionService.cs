using AutoMapper;
using Gudulion.BackEnd.DB;
using Gudulion.BackEnd.Moduls.Transaction.DTO;
using Gudulion.BackEnd.Moduls.Transaction.Model;
using Sweet.BackEnd.Exceprions;

namespace Gudulion.BackEnd.Moduls.Transaction.Service;

public class TransactionService : ITransactionService
{
    private readonly MainDbContext _db;
    private readonly IMapper _mapper;

    public TransactionService(MainDbContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    public Model.Transaction Create(AddTransactionDto dto)
    {
        var transaction = _mapper.Map<Model.Transaction>(dto);
        transaction.CreatedDate = DateTime.Now;
        _db.Transactions.Add(transaction);

        _db.SaveChanges();
        return transaction;
    }

    public void ChangeTransactionStatus(ChangeTransactionStatusDto dto)
    {
        var transactionFromDb = _db.Transactions.FirstOrDefault(a => a.Id == dto.TransactionId);
        if (transactionFromDb == null)
        {
            throw new NotFoundException("Transaction not found");
        }

        transactionFromDb.TransactionStatus = dto.NewStatus;
        if (dto.NewStatus == TransactionStatus.Confirmed)
        {
            transactionFromDb.ConfirmedDate = DateTime.Now;
        }

        _db.SaveChanges();
    }
}

public interface ITransactionService
{
    public Model.Transaction Create(AddTransactionDto dto);
    public void ChangeTransactionStatus(ChangeTransactionStatusDto dto);
}