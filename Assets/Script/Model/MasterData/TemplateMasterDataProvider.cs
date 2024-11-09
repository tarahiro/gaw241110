using System.Collections;
using UnityEngine;
using Tarahiro.MasterData;

namespace gaw241110.Model
{
    //---プロジェクト作成時にやること---//
    //namespaceの"project"部分を変更。（gaw[yymmdd].modelとか）

    //---クラス作成時にやること---//
    //"Template" を置換
    public class TemplateMasterDataProvider : MasterDataProvider<TemplateMasterData.Record,IMasterDataRecord<ITemplateMaster>>, ITemplateMasterDataProvider
    {
        protected override string m_pathName => "Data/Template";
    }
}