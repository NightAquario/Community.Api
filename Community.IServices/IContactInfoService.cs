using Community.DTO;

namespace Community.IServices;

public interface IContactInfoService
{
    Task<ContactInfo> GetContactInfo(int contactInfoId);
    Task<IQueryable<ContactInfo>> GetContactInfos();
    void AddContactInfo(ContactInfo contactInfo);
    void UpdateContactInfo(ContactInfo contactInfo);
    void DeleteContactInfo(int contactInfoId);
}
