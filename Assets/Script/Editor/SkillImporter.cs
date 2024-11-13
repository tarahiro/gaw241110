using System.Collections;
using UnityEngine;
using Tarahiro;
using Tarahiro.MasterData;
using Tarahiro.Editor.XmlImporter;
using System.Collections.Generic;
using UnityEditor;
using gaw241110.model;
using gaw241110.model.masterData;

namespace gaw241110.Editor
{
#if UNITY_EDITOR
    //---プロジェクト作成時にやること---//
    //namespaceの"project"部分を変更。（gaw[yymmdd]とか）
    //アセンブリ構成に応じて、using部分を追加（gaw[yymmdd].modelとか）

    //---クラス作成時にやること---//
    //"Template" を置換
    //ITemplateMasterに合わせてフィールドを追加
    internal sealed class SkillImporter
    {
        const string c_XmlPath = "ImportData/Skill/Skill.xml";
        const string c_SheetName = "Script";
        enum Columns
        {
            Index = 0,
            Id = 1,
            DisplayName = 2,
            Description = 3,
            CardImagePath = 4,
            SkillKey = 5,
            SkillLevel = 6,
            SkillArg = 7,
            CoreSkillKey = 8,
        }

        //--------------------------------------------------------------------
        // 読み込み
        //--------------------------------------------------------------------

        [MenuItem("Assets/Tables/Import Skill", false, 2)]
        static void ImportMenuSkill()
        {
            var stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start();

            Import();

            stopwatch.Stop();
            Log.DebugLog($"Skill imported in {stopwatch.ElapsedMilliseconds / 1000.0f} seconds.");
        }

        public static void Import()
        {
            var book = XmlImporter.ImportWorkbook(c_XmlPath);

            var SkillDataList = new List<SkillMasterData.Record>();

            var sheet = book.TryGetWorksheet(c_SheetName);
            if (sheet == null)
            {
                Log.DebugWarning($"シート: {c_SheetName} が見つかりませんでした。");
            }
            else
            {
                for (int row = 0; row < sheet.Height; ++row)
                {
                    // Indexの欄が有効な数字だったら読み込み
                    if (int.TryParse(sheet[row, (int)Columns.Index].String, out int index))
                    {
                        string id = sheet[row, (int)Columns.Id].String;
                        SkillDataList.Add(new SkillMasterData.Record(index, id)
                        {
                            SettableDisplayName = sheet[row, (int)Columns.DisplayName].String,
                            SettableDescription = sheet[row, (int)Columns.Description].String,
                            SettableCardImagePath = sheet[row, (int)Columns.CardImagePath].String,
                            SettableSkillKey = sheet[row, (int)Columns.SkillKey].String,
                            SettableSkillLevel = sheet[row, (int)Columns.SkillLevel].Int,
                            SettableSkillArg = sheet[row, (int)Columns.SkillArg].Float,
                            SettableCoreSkillKey = sheet[row, (int)Columns.CoreSkillKey].String,
                        });
                    }
                }
            }

            // データ出力
            XmlImporter.ExportOrderedDictionary<SkillMasterData, SkillMasterData.Record, IMasterDataRecord<ISkillMaster>>(SkillMasterData.c_DataPath, SkillDataList);
        }
    }
#endif
}