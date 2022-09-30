﻿using System;
using System.IO;
using aeX30.Entities;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.SS.Util;

namespace aeX30.Model
{
    public class ReportModel
    {
        private static string[] CellAddress = new string[]
                {
            /*auto. de serv.:------*/    "AB35", "AD35", "AF35", "AJ35", "AL35", "AM35", "AN35",
            
            /*prop. NOME:----------*/    "G43",
            /*prop. CPF:-----------*/    "AJ43",
            /*prop. DDD:-----------*/    "AP43",
            /*prop. TELEFONE:------*/    "AR43",
            
            /*rt. NOME:------------*/    "G46",
            /*rt. CAU_CREA:--------*/    "Z46",
            /*rt. UF:--------------*/    "AH46",
            /*rt. CPF:-------------*/    "AJ46",
            /*rt. DDD:-------------*/    "AP46",
            /*rt. TELEFONE:--------*/    "AR46",

            /*end. ENDEREÇO:-------*/    "G49",
            /*end. COMPLEMENTO:----*/    "AJ49",
            /*end. BAIRRO:---------*/    "G51",
            /*end. CEP:------------*/    "V51",
            /*end. MUNICIPIO:------*/    "AA51",
            /*end. UF:-------------*/    "AS51",
            
            /*imov. VALOR TERRENO:-*/    "G53",
            /*imov. MATRICULA:-----*/    "Q53",
            /*imov. OFICIO:--------*/    "AA53",
            /*imov. COMARCA:-------*/    "AJ53",
            /*imov. UF:------------*/    "AS53",
           
            /*17.01(%):------------*/    "S68",
            /*17.02(%):------------*/    "S69",
            /*17.03(%):------------*/    "S70",
            /*17.04(%):------------*/    "S71",
            /*17.05(%):------------*/    "S72",
            /*17.06(%):------------*/    "S73",
            /*17.07(%):------------*/    "S74",
            /*17.08(%):------------*/    "S75",
            /*17.09(%):------------*/    "S76",
            /*17.10(%):------------*/    "S77",
            /*17.11(%):------------*/    "S78",
            /*17.12(%):------------*/    "S79",
            /*17.13(%):------------*/    "S80",
            /*17.14(%):------------*/    "S81",
            /*17.15(%):------------*/    "S82",
            /*17.16(%):------------*/    "S83",
            /*17.17(%):------------*/    "S84",
            /*17.18(%):------------*/    "S85",
            /*17.19(%):------------*/    "S86",
            /*17.20(%):------------*/    "S87",
            /*ACUMULADO(%):--------*/    "Y89",

            /*contrato INICIO:-----*/    "AH63",
            /*contrato TERMINO:----*/    "AS63",

            /*ETAPA PREVISTA:------*/    "-",

            /*cron. EXECUTADO:-----*/    "AK71",
            /*cron. PARC 1:--------*/    "AK72",
            /*cron. PARC 2:--------*/    "AK73",
            /*cron. PARC 3:--------*/    "AK74",
            /*cron. PARC 4:--------*/    "AK75",
            /*cron. PARC 5:--------*/    "AK76",
            /*cron. PARC 6:--------*/    "AK77",
            /*cron. PARC 7:--------*/    "AK78",
            /*cron. PARC 8:--------*/    "AK79",
            /*cron. PARC 9:--------*/    "AK80",
            /*cron. PARC 10:-------*/    "AK81",
            /*cron. PARC 11:-------*/    "AK82",
            /*cron. PARC 12:-------*/    "AK83",
            /*cron. PARC 13:-------*/    "AK84",
            /*cron. PARC 14:-------*/    "AK85",
            /*cron. PARC 15:-------*/    "AK86",
            /*cron. PARC 16:-------*/    "AK87",
            /*cron. PARC 17:-------*/    "AK88",
            /*cron. PARC 18:-------*/    "AK89",
            /*cron. PARC 19:-------*/    "AK90",
            /*cron. PARC 20:-------*/    "AK91",
            /*cron. PARC 21:-------*/    "AK92",
            /*cron. PARC 22:-------*/    "AK93",
            /*cron. PARC 23:-------*/    "AK94",
            /*cron. PARC 24:-------*/    "AK95",
            /*cron. PARC 25:-------*/    "AK96",
            /*cron. PARC 26:-------*/    "AK97",
            /*cron. PARC 27:-------*/    "AK98",
            /*cron. PARC 28:-------*/    "AK99",
            /*cron. PARC 29:-------*/    "AK100",
            /*cron. PARC 30:-------*/    "AK101",
            /*versão.......:-------*/    "2022",
            /*cron. PARC 31:-------*/    "AK102",
            /*cron. PARC 32:-------*/    "AK103",
            /*cron. PARC 33:-------*/    "AK104",
            /*cron. PARC 34:-------*/    "AK105",
            /*cron. PARC 35:-------*/    "AK106",
            /*cron. PARC 36:-------*/    "AK107",

                };


        internal static string GetSheetName(string filePath)
        {
            FileStream file = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            HSSFWorkbook wbook = new HSSFWorkbook(file);

            return wbook.GetSheetName(0);
        }


        internal static string GetFooter(string filePath)
        {
            FileStream file = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            HSSFWorkbook wbook = new HSSFWorkbook(file);

            ISheet sheet = wbook.GetSheet(wbook.GetSheetName(0));

            return sheet.Footer.Left;
        }


        internal int SetReport(string pathTemplate, string pathDestin, Report report)
        {
            try
            {
                FileStream file = new FileStream(pathTemplate, FileMode.Open, FileAccess.Read);
                HSSFWorkbook wbook = new HSSFWorkbook(file);
                ISheet sheet = wbook.GetSheet("RAE");
                string[] xy = CellAddress;

                
                //CABEÇALHO
                sheet.GetRow(new CellReference(xy[0]).Row).GetCell(new CellReference(xy[0]).Col).SetCellValue(report.Ref0);
                sheet.GetRow(new CellReference(xy[1]).Row).GetCell(new CellReference(xy[1]).Col).SetCellValue(report.Ref1);
                sheet.GetRow(new CellReference(xy[2]).Row).GetCell(new CellReference(xy[2]).Col).SetCellValue(Convert.ToInt32(report.Ref2));
                sheet.GetRow(new CellReference(xy[3]).Row).GetCell(new CellReference(xy[3]).Col).SetCellValue(report.Ref3);
                sheet.GetRow(new CellReference(xy[4]).Row).GetCell(new CellReference(xy[4]).Col).SetCellValue(report.Ref4);
                sheet.GetRow(new CellReference(xy[5]).Row).GetCell(new CellReference(xy[5]).Col).SetCellValue(report.Ref5);
                sheet.GetRow(new CellReference(xy[6]).Row).GetCell(new CellReference(xy[6]).Col).SetCellValue(report.Ref6);
                sheet.GetRow(new CellReference(xy[7]).Row).GetCell(new CellReference(xy[7]).Col).SetCellValue(report.Prop_Nome);
                sheet.GetRow(new CellReference(xy[8]).Row).GetCell(new CellReference(xy[8]).Col).SetCellValue(report.Prop_CPF);
                sheet.GetRow(new CellReference(xy[9]).Row).GetCell(new CellReference(xy[9]).Col).SetCellValue(report.Prop_DDD);
                sheet.GetRow(new CellReference(xy[10]).Row).GetCell(new CellReference(xy[10]).Col).SetCellValue(report.Prop_Telefone);
                sheet.GetRow(new CellReference(xy[11]).Row).GetCell(new CellReference(xy[11]).Col).SetCellValue(report.Rt_Nome);
                sheet.GetRow(new CellReference(xy[12]).Row).GetCell(new CellReference(xy[12]).Col).SetCellValue(report.Rt_CAU_CREA);
                sheet.GetRow(new CellReference(xy[13]).Row).GetCell(new CellReference(xy[13]).Col).SetCellValue(report.Rt_UF);
                sheet.GetRow(new CellReference(xy[14]).Row).GetCell(new CellReference(xy[14]).Col).SetCellValue(report.Rt_CPF);
                sheet.GetRow(new CellReference(xy[15]).Row).GetCell(new CellReference(xy[15]).Col).SetCellValue(report.Rt_DDD);
                sheet.GetRow(new CellReference(xy[16]).Row).GetCell(new CellReference(xy[16]).Col).SetCellValue(report.Rt_Telefone);
                sheet.GetRow(new CellReference(xy[17]).Row).GetCell(new CellReference(xy[17]).Col).SetCellValue(report.End_Endereco);
                sheet.GetRow(new CellReference(xy[18]).Row).GetCell(new CellReference(xy[18]).Col).SetCellValue(report.End_Complemento);
                sheet.GetRow(new CellReference(xy[19]).Row).GetCell(new CellReference(xy[19]).Col).SetCellValue(report.End_Bairro);
                sheet.GetRow(new CellReference(xy[20]).Row).GetCell(new CellReference(xy[20]).Col).SetCellValue(report.End_CEP);
                sheet.GetRow(new CellReference(xy[21]).Row).GetCell(new CellReference(xy[21]).Col).SetCellValue(report.End_Municipio);
                sheet.GetRow(new CellReference(xy[22]).Row).GetCell(new CellReference(xy[22]).Col).SetCellValue(report.End_UF);
                sheet.GetRow(new CellReference(xy[23]).Row).GetCell(new CellReference(xy[23]).Col).SetCellValue(report.Imov_Valor_Terreno);
                sheet.GetRow(new CellReference(xy[24]).Row).GetCell(new CellReference(xy[24]).Col).SetCellValue(report.Imov_Matricula);
                sheet.GetRow(new CellReference(xy[25]).Row).GetCell(new CellReference(xy[25]).Col).SetCellValue(report.Imov_Oficio);
                sheet.GetRow(new CellReference(xy[26]).Row).GetCell(new CellReference(xy[26]).Col).SetCellValue(report.Imov_Comarca);
                sheet.GetRow(new CellReference(xy[27]).Row).GetCell(new CellReference(xy[27]).Col).SetCellValue(report.Imov_UF);
                //ORÇAMENTO (PERCENTUAIS)
                sheet.GetRow(new CellReference(xy[28]).Row).GetCell(new CellReference(xy[28]).Col).SetCellValue(Convert.ToDouble(report.Item_17_01));
                sheet.GetRow(new CellReference(xy[29]).Row).GetCell(new CellReference(xy[29]).Col).SetCellValue(Convert.ToDouble(report.Item_17_02));
                sheet.GetRow(new CellReference(xy[30]).Row).GetCell(new CellReference(xy[30]).Col).SetCellValue(Convert.ToDouble(report.Item_17_03));
                sheet.GetRow(new CellReference(xy[31]).Row).GetCell(new CellReference(xy[31]).Col).SetCellValue(Convert.ToDouble(report.Item_17_04));
                sheet.GetRow(new CellReference(xy[32]).Row).GetCell(new CellReference(xy[32]).Col).SetCellValue(Convert.ToDouble(report.Item_17_05));
                sheet.GetRow(new CellReference(xy[33]).Row).GetCell(new CellReference(xy[33]).Col).SetCellValue(Convert.ToDouble(report.Item_17_06));
                sheet.GetRow(new CellReference(xy[34]).Row).GetCell(new CellReference(xy[34]).Col).SetCellValue(Convert.ToDouble(report.Item_17_07));
                sheet.GetRow(new CellReference(xy[35]).Row).GetCell(new CellReference(xy[35]).Col).SetCellValue(Convert.ToDouble(report.Item_17_08));
                sheet.GetRow(new CellReference(xy[36]).Row).GetCell(new CellReference(xy[36]).Col).SetCellValue(Convert.ToDouble(report.Item_17_09));
                sheet.GetRow(new CellReference(xy[37]).Row).GetCell(new CellReference(xy[37]).Col).SetCellValue(Convert.ToDouble(report.Item_17_10));
                sheet.GetRow(new CellReference(xy[38]).Row).GetCell(new CellReference(xy[38]).Col).SetCellValue(Convert.ToDouble(report.Item_17_11));
                sheet.GetRow(new CellReference(xy[39]).Row).GetCell(new CellReference(xy[39]).Col).SetCellValue(Convert.ToDouble(report.Item_17_12));
                sheet.GetRow(new CellReference(xy[40]).Row).GetCell(new CellReference(xy[40]).Col).SetCellValue(Convert.ToDouble(report.Item_17_13));
                sheet.GetRow(new CellReference(xy[41]).Row).GetCell(new CellReference(xy[41]).Col).SetCellValue(Convert.ToDouble(report.Item_17_14));
                sheet.GetRow(new CellReference(xy[42]).Row).GetCell(new CellReference(xy[42]).Col).SetCellValue(Convert.ToDouble(report.Item_17_15));
                sheet.GetRow(new CellReference(xy[43]).Row).GetCell(new CellReference(xy[43]).Col).SetCellValue(Convert.ToDouble(report.Item_17_16));
                sheet.GetRow(new CellReference(xy[44]).Row).GetCell(new CellReference(xy[44]).Col).SetCellValue(Convert.ToDouble(report.Item_17_17));
                sheet.GetRow(new CellReference(xy[45]).Row).GetCell(new CellReference(xy[45]).Col).SetCellValue(Convert.ToDouble(report.Item_17_18));
                sheet.GetRow(new CellReference(xy[46]).Row).GetCell(new CellReference(xy[46]).Col).SetCellValue(Convert.ToDouble(report.Item_17_19));
                sheet.GetRow(new CellReference(xy[47]).Row).GetCell(new CellReference(xy[47]).Col).SetCellValue(Convert.ToDouble(report.Item_17_20));
                if (report.MensuradoAcumulado != "")
                    sheet.GetRow(new CellReference(xy[48]).Row).GetCell(new CellReference(xy[48]).Col).SetCellValue(Convert.ToDouble(report.MensuradoAcumulado));
                //DADOS ADICIONAIS
                if (report.ContratoInicio != "  /  /")
                    sheet.GetRow(new CellReference(xy[49]).Row).GetCell(new CellReference(xy[49]).Col).SetCellValue(report.ContratoInicio);
                if (report.ContratoTermino != "  /  /")
                    sheet.GetRow(new CellReference(xy[50]).Row).GetCell(new CellReference(xy[50]).Col).SetCellValue(report.ContratoTermino);


                if (xy[83] != "2022")
                    sheet.GetRow(new CellReference(xy[51]).Row).GetCell(new CellReference(xy[51]).Col).SetCellValue(report.EtapaPrevista);

                ////CRONOGRAMA
                sheet.GetRow(new CellReference(xy[52]).Row).GetCell(new CellReference(xy[52]).Col).SetCellValue(Convert.ToDouble(report.Cron_Executado));
                sheet.GetRow(new CellReference(xy[53]).Row).GetCell(new CellReference(xy[53]).Col).SetCellValue(Convert.ToDouble(report.Cron_Parc_1));
                sheet.GetRow(new CellReference(xy[54]).Row).GetCell(new CellReference(xy[54]).Col).SetCellValue(Convert.ToDouble(report.Cron_Parc_2));
                sheet.GetRow(new CellReference(xy[55]).Row).GetCell(new CellReference(xy[55]).Col).SetCellValue(Convert.ToDouble(report.Cron_Parc_3));
                sheet.GetRow(new CellReference(xy[56]).Row).GetCell(new CellReference(xy[56]).Col).SetCellValue(Convert.ToDouble(report.Cron_Parc_4));
                sheet.GetRow(new CellReference(xy[57]).Row).GetCell(new CellReference(xy[57]).Col).SetCellValue(Convert.ToDouble(report.Cron_Parc_5));
                sheet.GetRow(new CellReference(xy[58]).Row).GetCell(new CellReference(xy[58]).Col).SetCellValue(Convert.ToDouble(report.Cron_Parc_6));
                sheet.GetRow(new CellReference(xy[59]).Row).GetCell(new CellReference(xy[59]).Col).SetCellValue(Convert.ToDouble(report.Cron_Parc_7));
                sheet.GetRow(new CellReference(xy[60]).Row).GetCell(new CellReference(xy[60]).Col).SetCellValue(Convert.ToDouble(report.Cron_Parc_8));
                sheet.GetRow(new CellReference(xy[61]).Row).GetCell(new CellReference(xy[61]).Col).SetCellValue(Convert.ToDouble(report.Cron_Parc_9));
                sheet.GetRow(new CellReference(xy[62]).Row).GetCell(new CellReference(xy[62]).Col).SetCellValue(Convert.ToDouble(report.Cron_Parc_10));
                sheet.GetRow(new CellReference(xy[63]).Row).GetCell(new CellReference(xy[63]).Col).SetCellValue(Convert.ToDouble(report.Cron_Parc_11));
                sheet.GetRow(new CellReference(xy[64]).Row).GetCell(new CellReference(xy[64]).Col).SetCellValue(Convert.ToDouble(report.Cron_Parc_12));
                sheet.GetRow(new CellReference(xy[65]).Row).GetCell(new CellReference(xy[65]).Col).SetCellValue(Convert.ToDouble(report.Cron_Parc_13));
                sheet.GetRow(new CellReference(xy[66]).Row).GetCell(new CellReference(xy[66]).Col).SetCellValue(Convert.ToDouble(report.Cron_Parc_14));
                sheet.GetRow(new CellReference(xy[67]).Row).GetCell(new CellReference(xy[67]).Col).SetCellValue(Convert.ToDouble(report.Cron_Parc_15));
                sheet.GetRow(new CellReference(xy[68]).Row).GetCell(new CellReference(xy[68]).Col).SetCellValue(Convert.ToDouble(report.Cron_Parc_16));
                sheet.GetRow(new CellReference(xy[69]).Row).GetCell(new CellReference(xy[69]).Col).SetCellValue(Convert.ToDouble(report.Cron_Parc_17));
                sheet.GetRow(new CellReference(xy[70]).Row).GetCell(new CellReference(xy[70]).Col).SetCellValue(Convert.ToDouble(report.Cron_Parc_18));
                sheet.GetRow(new CellReference(xy[71]).Row).GetCell(new CellReference(xy[71]).Col).SetCellValue(Convert.ToDouble(report.Cron_Parc_19));
                sheet.GetRow(new CellReference(xy[72]).Row).GetCell(new CellReference(xy[72]).Col).SetCellValue(Convert.ToDouble(report.Cron_Parc_20));
                sheet.GetRow(new CellReference(xy[73]).Row).GetCell(new CellReference(xy[73]).Col).SetCellValue(Convert.ToDouble(report.Cron_Parc_21));
                sheet.GetRow(new CellReference(xy[74]).Row).GetCell(new CellReference(xy[74]).Col).SetCellValue(Convert.ToDouble(report.Cron_Parc_22));
                sheet.GetRow(new CellReference(xy[75]).Row).GetCell(new CellReference(xy[75]).Col).SetCellValue(Convert.ToDouble(report.Cron_Parc_23));
                sheet.GetRow(new CellReference(xy[76]).Row).GetCell(new CellReference(xy[76]).Col).SetCellValue(Convert.ToDouble(report.Cron_Parc_24));
                sheet.GetRow(new CellReference(xy[77]).Row).GetCell(new CellReference(xy[77]).Col).SetCellValue(Convert.ToDouble(report.Cron_Parc_25));
                sheet.GetRow(new CellReference(xy[78]).Row).GetCell(new CellReference(xy[78]).Col).SetCellValue(Convert.ToDouble(report.Cron_Parc_26));
                sheet.GetRow(new CellReference(xy[79]).Row).GetCell(new CellReference(xy[79]).Col).SetCellValue(Convert.ToDouble(report.Cron_Parc_27));
                sheet.GetRow(new CellReference(xy[80]).Row).GetCell(new CellReference(xy[80]).Col).SetCellValue(Convert.ToDouble(report.Cron_Parc_28));
                sheet.GetRow(new CellReference(xy[81]).Row).GetCell(new CellReference(xy[81]).Col).SetCellValue(Convert.ToDouble(report.Cron_Parc_29));
                sheet.GetRow(new CellReference(xy[82]).Row).GetCell(new CellReference(xy[82]).Col).SetCellValue(Convert.ToDouble(report.Cron_Parc_30));
                sheet.GetRow(new CellReference(xy[84]).Row).GetCell(new CellReference(xy[84]).Col).SetCellValue(Convert.ToDouble(report.Cron_Parc_31));
                sheet.GetRow(new CellReference(xy[85]).Row).GetCell(new CellReference(xy[85]).Col).SetCellValue(Convert.ToDouble(report.Cron_Parc_32));
                sheet.GetRow(new CellReference(xy[86]).Row).GetCell(new CellReference(xy[86]).Col).SetCellValue(Convert.ToDouble(report.Cron_Parc_33));
                sheet.GetRow(new CellReference(xy[87]).Row).GetCell(new CellReference(xy[87]).Col).SetCellValue(Convert.ToDouble(report.Cron_Parc_34));
                sheet.GetRow(new CellReference(xy[88]).Row).GetCell(new CellReference(xy[88]).Col).SetCellValue(Convert.ToDouble(report.Cron_Parc_35));
                sheet.GetRow(new CellReference(xy[89]).Row).GetCell(new CellReference(xy[89]).Col).SetCellValue(Convert.ToDouble(report.Cron_Parc_36));



                using (FileStream arquivoRAE = new FileStream(pathDestin, FileMode.Create, FileAccess.Write))
                {
                    wbook.ForceFormulaRecalculation = true;
                    wbook.Write(arquivoRAE);
                }
                return 1;

            }
            catch
            {
                return 0;
            }

        }

    }
}

