using System.Collections;
using UnityEngine;
using Tarahiro;

namespace gaw241110.model
{
    //---プロジェクト作成時にやること---//
    //namespaceの"project"部分を変更。（gaw[yymmdd].modelとか）

    //---クラス作成時にやること---//
    //"Template" を置換
    //フィールドを追加
    //1番目
    public interface ISkillMaster : IIdentifiable, IIndexable
    {

        /// <summary>
        /// このデータのIDを取得します。
        /// </summary>

        string DisplayName { get; }
        string Description{ get; }
        string CardImagePath { get; }
        string SkillKey { get; }
        float SkillArg { get; }
    }
}