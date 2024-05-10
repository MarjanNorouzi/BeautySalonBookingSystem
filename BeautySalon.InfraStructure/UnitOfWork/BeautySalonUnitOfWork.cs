using BeautySalon.Domain.Entities;
using BeautySalon.Domain.Entities.IdentityModels;
using BeautySalon.InfraStructure.Contexts;
using BeautySalon.InfraStructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BeautySalon.InfraStructure.UnitOfWork
{
    public class BeautySalonUnitOfWork : IBeautySalonUnitOfWork, IDisposable
    {
        private readonly BeautySalonContext _context;
        private readonly CancellationToken _cancellationToken;
        private bool disposed = false;

        private GenericRepository<Appointment, BeautySalonContext>? _appointmentRepository;
        private GenericRepository<Customer, BeautySalonContext>? _customerRepository;
        private GenericRepository<MainService, BeautySalonContext>? _mainServiceRepository;
        private GenericRepository<Subservice, BeautySalonContext>? _subserviceRepository;
        private GenericRepository<Operator, BeautySalonContext>? _operatorRepository;
        private GenericRepository<SubserviceOperator, BeautySalonContext>? _subserviceOperatorRepository;
        private GenericRepository<ApplicationRole, BeautySalonContext>? _applicationRoleRepository;
        private GenericRepository<ApplicationUser, BeautySalonContext>? _applicationUserRepository;
        private GenericRepository<ApplicationUserRole, BeautySalonContext>? _applicationUserRoleRepository;

        public BeautySalonUnitOfWork(BeautySalonContext context, CancellationToken cancellationToken) //: base(context, cancellationToken)
        {
            _context = context;
            _cancellationToken = cancellationToken;
        }

        public string ConnectionString => this._context.Database.GetConnectionString() ?? string.Empty;

        public GenericRepository<Appointment, BeautySalonContext> AppointmentRepository
        {
            get
            {
                _appointmentRepository ??= new GenericRepository<Appointment, BeautySalonContext>(_context, _cancellationToken);
                return _appointmentRepository;
            }
        }

        public GenericRepository<Customer, BeautySalonContext> CustomerRepository
        {
            get
            {
                _customerRepository ??= new GenericRepository<Customer, BeautySalonContext>(_context, _cancellationToken);
                return _customerRepository;
            }
        }

        public GenericRepository<MainService, BeautySalonContext> MainServiceRepository
        {
            get
            {
                _mainServiceRepository ??= new GenericRepository<MainService, BeautySalonContext>(_context, _cancellationToken);
                return _mainServiceRepository;
            }
        }

        public GenericRepository<Subservice, BeautySalonContext> SubserviceRepository
        {
            get
            {
                _subserviceRepository ??= new GenericRepository<Subservice, BeautySalonContext>(_context, _cancellationToken);
                return _subserviceRepository;
            }
        }

        public GenericRepository<Operator, BeautySalonContext> OperatorRepository
        {
            get
            {
                _operatorRepository ??= new GenericRepository<Operator, BeautySalonContext>(_context, _cancellationToken);
                return _operatorRepository;
            }
        }

        public GenericRepository<SubserviceOperator, BeautySalonContext> SubserviceOperatorRepository
        {
            get
            {
                _subserviceOperatorRepository ??= new GenericRepository<SubserviceOperator, BeautySalonContext>(_context, _cancellationToken);
                return _subserviceOperatorRepository;
            }
        }

        public GenericRepository<ApplicationRole, BeautySalonContext> ApplicationRoleRepository
        {
            get
            {
                _applicationRoleRepository ??= new GenericRepository<ApplicationRole, BeautySalonContext>(_context, _cancellationToken);
                return _applicationRoleRepository;
            }
        }

        public GenericRepository<ApplicationUser, BeautySalonContext> ApplicationUserRepository
        {
            get
            {
                _applicationUserRepository ??= new GenericRepository<ApplicationUser, BeautySalonContext>(_context, _cancellationToken);
                return _applicationUserRepository;
            }
        }

        public GenericRepository<ApplicationUserRole, BeautySalonContext> ApplicationUserRoleRepository
        {
            get
            {
                _applicationUserRoleRepository ??= new GenericRepository<ApplicationUserRole, BeautySalonContext>(_context, _cancellationToken);
                return _applicationUserRoleRepository;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public async ValueTask DisposeAsync()
        {
            if (!disposed)
            {
                await _context.DisposeAsync();
                GC.SuppressFinalize(this);
            }
            disposed = true;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }

    public interface IBeautySalonUnitOfWork //: IBeautySalonRepositoryBase
    {
        string ConnectionString { get; }

        GenericRepository<Appointment, BeautySalonContext>? AppointmentRepository { get; }
        GenericRepository<Customer, BeautySalonContext>? CustomerRepository { get; }
        GenericRepository<MainService, BeautySalonContext>? MainServiceRepository { get; }
        GenericRepository<Subservice, BeautySalonContext>? SubserviceRepository { get; }
        GenericRepository<Operator, BeautySalonContext>? OperatorRepository { get; }
        GenericRepository<SubserviceOperator, BeautySalonContext>? SubserviceOperatorRepository { get; }
        GenericRepository<ApplicationRole, BeautySalonContext>? ApplicationRoleRepository { get; }
        GenericRepository<ApplicationUser, BeautySalonContext>? ApplicationUserRepository { get; }
        GenericRepository<ApplicationUserRole, BeautySalonContext>? ApplicationUserRoleRepository { get; }
    }

    public interface IBeautySalonRepositoryBase
    {
        //public ValueTask<IEnumerable<TResult>?> QueryAsync<TResult>(DapperQueryParameter qParameter);
        //public ValueTask<TResult?> QueryFirstOrDefaultAsync<TResult>(DapperQueryParameter qParameter);
        //public Task<GridReader> QueryMultipleAsync(DapperQueryParameter qParameter);
        //public Task<int?> CommandAsync(DapperQueryParameter qParameter);
        //public ValueTask<int> SaveAsync();
        //public Task<TempTable<T>> CreateTempTableAsync<T>(IQueryable<T> items) where T : class;
        //public Task<TempTable<T>> CreateTempTableAsync<T>(IEnumerable<T> items) where T : class;
        //public Task<TempTable<T>> CreateTempTableAsync<T>() where T : class;
        //public Task<TempTable<T>> CreateTempTableAsyncWithIdentityInsert<T>(IQueryable<T> items, bool keepIdentity = true) where T : class;
        //public Task<TempTable<T>> CreateTempTableAsyncWithIdentityInsert<T>(IEnumerable<T> items) where T : class;
        public void Dispose(bool disposing);
        public ValueTask DisposeAsync();
        public void Dispose();
    }
}