using Community.DTO;
using Community.IRepositories;
using Community.IServices;

namespace Community.Services;

public sealed class ContactInfoService : IContactInfoService
{
    private readonly IUnitOfWork _unitOfWork;

    public ContactInfoService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public Task<ContactInfo> GetContactInfo(int contactInfoId)
    {
        ContactInfo contactInfo = _unitOfWork.ContactInfoRepository.GetById(contactInfoId) ?? 
            throw new InvalidDataException($"Contact Information with id : {contactInfoId} could not be found");

        return Task.FromResult(contactInfo);
    }
    public Task<IQueryable<ContactInfo>> GetContactInfos()
    {
        throw new NotImplementedException();
    }
    public void AddContactInfo(ContactInfo contactInfo)
    {
        _unitOfWork.ContactInfoRepository.Insert(contactInfo);
        _unitOfWork.SaveChanges();
    }
    public void UpdateContactInfo(ContactInfo contactInfo)
    {
        if (contactInfo == null) throw new ArgumentNullException(nameof(contactInfo));
        _unitOfWork.ContactInfoRepository.Update(contactInfo);
        _unitOfWork.SaveChanges();
    }
    public void DeleteContactInfo(int contactInfoId)
    {
        ContactInfo contactInfo = _unitOfWork.ContactInfoRepository.GetById(contactInfoId);
        contactInfo.IsActive = false;
        _unitOfWork.SaveChanges();
    }

}
