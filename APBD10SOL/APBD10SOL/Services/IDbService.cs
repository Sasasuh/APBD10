namespace APBD10SOL.Services;

public interface IDbService
{
    Task<bool> DoesPatientExistAsync(int id);
    Task<bool> DoesDoctorExistAsync(int id);
    Task<bool> DoesMedicamentExistAsync(int id);
    Task<bool> DoesPrescriptionExistAsync(int id);

}