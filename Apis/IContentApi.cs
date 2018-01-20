﻿using System.Collections.Generic;

namespace SiteServer.Plugin.Apis
{
    public interface IContentApi
    {
        IContentInfo NewInstance();

        IContentInfo GetContentInfo(int publishmentSystemId, int channelId, int contentId);

        List<IContentInfo> GetContentInfoList(int publishmentSystemId, int channelId, string whereString,
            string orderString, int limit, int offset);

        List<int> GetContentIdList(int publishmentSystemId, int channelId);

        int GetCount(int publishmentSystemId, int channelId, string whereString);

        string GetContentValue(int publishmentSystemId, int channelId, int contentId, string attributeName);

        string GetTableName(int publishmentSystemId, int channelId);

        List<TableColumn> GetTableColumns(int publishmentSystemId, int channelId);

        int Insert(int publishmentSystemId, int channelId, IContentInfo contentInfo);

        void Update(int publishmentSystemId, int channelId, IContentInfo contentInfo);

        void Delete(int publishmentSystemId, int channelId, int contentId);
    }
}
