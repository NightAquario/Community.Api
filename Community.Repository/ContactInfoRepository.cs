﻿using Community.DBC;
using Community.DTO;
using Community.RepositoryInterfaces;

namespace Community.Repositories;

internal sealed class ContactInfoRepository : RepositoryBase<ContactInfo>, IContactInfoRepository
{
    internal ContactInfoRepository(CommunityDBContext context) : base(context)
    {

    }
}
