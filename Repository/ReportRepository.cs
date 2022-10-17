﻿using AeX30.Entities;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using System;
using System.IO;

namespace AeX30.Repository
{
    public class ReportRepository
    {

        public static string GetSheetName(string filePath)
        {
            FileStream file = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            HSSFWorkbook wbook = new HSSFWorkbook(file);

            return wbook.GetSheetName(0);
        }

        public static string GetLeftFooter(string filePath)
        {
            FileStream file = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            HSSFWorkbook wbook = new HSSFWorkbook(file);
            ISheet sheet = wbook.GetSheet(wbook.GetSheetName(0));

            return sheet.Footer.Left;
        }


        public static void SetReport(string pathTemplate, string pathDestin, Report report)
        {
            string[] cellReference = new string[]
        {
            /*auto. de serv.:------*/    "AB35", "AD35", "AF35", "AJ35", "AL35", "AM35", "-",
            
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

            try
            {
                FileStream file = new FileStream(pathTemplate, FileMode.Open, FileAccess.Read);
                HSSFWorkbook wbook = new HSSFWorkbook(file);
                ISheet sheet = wbook.GetSheet("RAE");


                //CABEÇALHO
                sheet.GetRow(new CellReference(cellReference[0]).Row).GetCell(new CellReference(cellReference[0]).Col).SetCellValue(report.Referencia[1]);
                sheet.GetRow(new CellReference(cellReference[1]).Row).GetCell(new CellReference(cellReference[1]).Col).SetCellValue(report.Referencia[2]);
                sheet.GetRow(new CellReference(cellReference[2]).Row).GetCell(new CellReference(cellReference[2]).Col).SetCellValue(Convert.ToInt32(report.Referencia[3]));
                sheet.GetRow(new CellReference(cellReference[3]).Row).GetCell(new CellReference(cellReference[3]).Col).SetCellValue(report.Referencia[4]);
                sheet.GetRow(new CellReference(cellReference[4]).Row).GetCell(new CellReference(cellReference[4]).Col).SetCellValue(report.Referencia[5]);
                sheet.GetRow(new CellReference(cellReference[5]).Row).GetCell(new CellReference(cellReference[5]).Col).SetCellValue(report.Referencia[6]);

                sheet.GetRow(new CellReference(cellReference[7]).Row).GetCell(new CellReference(cellReference[7]).Col).SetCellValue(report.ProponenteNome);
                sheet.GetRow(new CellReference(cellReference[8]).Row).GetCell(new CellReference(cellReference[8]).Col).SetCellValue(report.ProponenteCPF);
                sheet.GetRow(new CellReference(cellReference[9]).Row).GetCell(new CellReference(cellReference[9]).Col).SetCellValue(report.ProponenteDDD);
                sheet.GetRow(new CellReference(cellReference[10]).Row).GetCell(new CellReference(cellReference[10]).Col).SetCellValue(report.ProponenteFone);
                sheet.GetRow(new CellReference(cellReference[11]).Row).GetCell(new CellReference(cellReference[11]).Col).SetCellValue(report.ResponsavelNome);
                sheet.GetRow(new CellReference(cellReference[12]).Row).GetCell(new CellReference(cellReference[12]).Col).SetCellValue(report.ReponsavelCauCrea);
                sheet.GetRow(new CellReference(cellReference[13]).Row).GetCell(new CellReference(cellReference[13]).Col).SetCellValue(report.ResponsavelUF);
                sheet.GetRow(new CellReference(cellReference[14]).Row).GetCell(new CellReference(cellReference[14]).Col).SetCellValue(report.ResponsavelCPF);
                sheet.GetRow(new CellReference(cellReference[15]).Row).GetCell(new CellReference(cellReference[15]).Col).SetCellValue(report.ResponsavelDDD);
                sheet.GetRow(new CellReference(cellReference[16]).Row).GetCell(new CellReference(cellReference[16]).Col).SetCellValue(report.ResponsavelFone);
                sheet.GetRow(new CellReference(cellReference[17]).Row).GetCell(new CellReference(cellReference[17]).Col).SetCellValue(report.ImovelEndereco);
                sheet.GetRow(new CellReference(cellReference[18]).Row).GetCell(new CellReference(cellReference[18]).Col).SetCellValue(report.ImovelComplemento);
                sheet.GetRow(new CellReference(cellReference[19]).Row).GetCell(new CellReference(cellReference[19]).Col).SetCellValue(report.ImovelBairro);
                sheet.GetRow(new CellReference(cellReference[20]).Row).GetCell(new CellReference(cellReference[20]).Col).SetCellValue(report.ImovelCep);
                sheet.GetRow(new CellReference(cellReference[21]).Row).GetCell(new CellReference(cellReference[21]).Col).SetCellValue(report.ImovelMunicipio);
                sheet.GetRow(new CellReference(cellReference[22]).Row).GetCell(new CellReference(cellReference[22]).Col).SetCellValue(report.ImovelUF);
                sheet.GetRow(new CellReference(cellReference[23]).Row).GetCell(new CellReference(cellReference[23]).Col).SetCellValue(report.ImovelValorTerreno);
                sheet.GetRow(new CellReference(cellReference[24]).Row).GetCell(new CellReference(cellReference[24]).Col).SetCellValue(report.ImovelMatricula);
                sheet.GetRow(new CellReference(cellReference[25]).Row).GetCell(new CellReference(cellReference[25]).Col).SetCellValue(report.ImovelOficio);
                sheet.GetRow(new CellReference(cellReference[26]).Row).GetCell(new CellReference(cellReference[26]).Col).SetCellValue(report.ImovelComarca);
                sheet.GetRow(new CellReference(cellReference[27]).Row).GetCell(new CellReference(cellReference[27]).Col).SetCellValue(report.ImovelComarcaUF);
                //ORÇAMENTO (PERCENTUAIS)
                sheet.GetRow(new CellReference(cellReference[28]).Row).GetCell(new CellReference(cellReference[28]).Col).SetCellValue(Convert.ToDouble(report.ServicoItem01));
                sheet.GetRow(new CellReference(cellReference[29]).Row).GetCell(new CellReference(cellReference[29]).Col).SetCellValue(Convert.ToDouble(report.ServicoItem02));
                sheet.GetRow(new CellReference(cellReference[30]).Row).GetCell(new CellReference(cellReference[30]).Col).SetCellValue(Convert.ToDouble(report.ServicoItem03));
                sheet.GetRow(new CellReference(cellReference[31]).Row).GetCell(new CellReference(cellReference[31]).Col).SetCellValue(Convert.ToDouble(report.ServicoItem04));
                sheet.GetRow(new CellReference(cellReference[32]).Row).GetCell(new CellReference(cellReference[32]).Col).SetCellValue(Convert.ToDouble(report.ServicoItem05));
                sheet.GetRow(new CellReference(cellReference[33]).Row).GetCell(new CellReference(cellReference[33]).Col).SetCellValue(Convert.ToDouble(report.ServicoItem06));
                sheet.GetRow(new CellReference(cellReference[34]).Row).GetCell(new CellReference(cellReference[34]).Col).SetCellValue(Convert.ToDouble(report.ServicoItem07));
                sheet.GetRow(new CellReference(cellReference[35]).Row).GetCell(new CellReference(cellReference[35]).Col).SetCellValue(Convert.ToDouble(report.ServicoItem08));
                sheet.GetRow(new CellReference(cellReference[36]).Row).GetCell(new CellReference(cellReference[36]).Col).SetCellValue(Convert.ToDouble(report.ServicoItem09));
                sheet.GetRow(new CellReference(cellReference[37]).Row).GetCell(new CellReference(cellReference[37]).Col).SetCellValue(Convert.ToDouble(report.ServicoItem10));
                sheet.GetRow(new CellReference(cellReference[38]).Row).GetCell(new CellReference(cellReference[38]).Col).SetCellValue(Convert.ToDouble(report.ServicoItem11));
                sheet.GetRow(new CellReference(cellReference[39]).Row).GetCell(new CellReference(cellReference[39]).Col).SetCellValue(Convert.ToDouble(report.ServicoItem12));
                sheet.GetRow(new CellReference(cellReference[40]).Row).GetCell(new CellReference(cellReference[40]).Col).SetCellValue(Convert.ToDouble(report.ServicoItem13));
                sheet.GetRow(new CellReference(cellReference[41]).Row).GetCell(new CellReference(cellReference[41]).Col).SetCellValue(Convert.ToDouble(report.ServicoItem14));
                sheet.GetRow(new CellReference(cellReference[42]).Row).GetCell(new CellReference(cellReference[42]).Col).SetCellValue(Convert.ToDouble(report.ServicoItem15));
                sheet.GetRow(new CellReference(cellReference[43]).Row).GetCell(new CellReference(cellReference[43]).Col).SetCellValue(Convert.ToDouble(report.ServicoItem16));
                sheet.GetRow(new CellReference(cellReference[44]).Row).GetCell(new CellReference(cellReference[44]).Col).SetCellValue(Convert.ToDouble(report.ServicoItem17));
                sheet.GetRow(new CellReference(cellReference[45]).Row).GetCell(new CellReference(cellReference[45]).Col).SetCellValue(Convert.ToDouble(report.ServicoItem18));
                sheet.GetRow(new CellReference(cellReference[46]).Row).GetCell(new CellReference(cellReference[46]).Col).SetCellValue(Convert.ToDouble(report.ServicoItem19));
                sheet.GetRow(new CellReference(cellReference[47]).Row).GetCell(new CellReference(cellReference[47]).Col).SetCellValue(Convert.ToDouble(report.ServicoItem20));
                if (report.MensuradoAcumulado != "")
                    sheet.GetRow(new CellReference(cellReference[48]).Row).GetCell(new CellReference(cellReference[48]).Col).SetCellValue(Convert.ToDouble(report.MensuradoAcumulado));
                //DADOS ADICIONAIS
                if (report.ContratoInicio != "  /  /")
                    sheet.GetRow(new CellReference(cellReference[49]).Row).GetCell(new CellReference(cellReference[49]).Col).SetCellValue(report.ContratoInicio);
                if (report.ContratoTermino != "  /  /")
                    sheet.GetRow(new CellReference(cellReference[50]).Row).GetCell(new CellReference(cellReference[50]).Col).SetCellValue(report.ContratoTermino);


                ////CRONOGRAMA
                sheet.GetRow(new CellReference(cellReference[51]).Row).GetCell(new CellReference(cellReference[51]).Col).SetCellValue(Convert.ToDouble(report.CronogramaExecutado));
                sheet.GetRow(new CellReference(cellReference[52]).Row).GetCell(new CellReference(cellReference[52]).Col).SetCellValue(Convert.ToDouble(report.CronogramaEtapa1));
                sheet.GetRow(new CellReference(cellReference[53]).Row).GetCell(new CellReference(cellReference[53]).Col).SetCellValue(Convert.ToDouble(report.CronogramaEtapa2));
                sheet.GetRow(new CellReference(cellReference[54]).Row).GetCell(new CellReference(cellReference[54]).Col).SetCellValue(Convert.ToDouble(report.CronogramaEtapa3));
                sheet.GetRow(new CellReference(cellReference[55]).Row).GetCell(new CellReference(cellReference[55]).Col).SetCellValue(Convert.ToDouble(report.CronogramaEtapa4));
                sheet.GetRow(new CellReference(cellReference[56]).Row).GetCell(new CellReference(cellReference[56]).Col).SetCellValue(Convert.ToDouble(report.CronogramaEtapa5));
                sheet.GetRow(new CellReference(cellReference[57]).Row).GetCell(new CellReference(cellReference[57]).Col).SetCellValue(Convert.ToDouble(report.CronogramaEtapa6));
                sheet.GetRow(new CellReference(cellReference[58]).Row).GetCell(new CellReference(cellReference[58]).Col).SetCellValue(Convert.ToDouble(report.CronogramaEtapa7));
                sheet.GetRow(new CellReference(cellReference[59]).Row).GetCell(new CellReference(cellReference[59]).Col).SetCellValue(Convert.ToDouble(report.CronogramaEtapa8));
                sheet.GetRow(new CellReference(cellReference[60]).Row).GetCell(new CellReference(cellReference[60]).Col).SetCellValue(Convert.ToDouble(report.CronogramaEtapa9));
                sheet.GetRow(new CellReference(cellReference[61]).Row).GetCell(new CellReference(cellReference[61]).Col).SetCellValue(Convert.ToDouble(report.CronogramaEtapa10));
                sheet.GetRow(new CellReference(cellReference[62]).Row).GetCell(new CellReference(cellReference[62]).Col).SetCellValue(Convert.ToDouble(report.CronogramaEtapa11));
                sheet.GetRow(new CellReference(cellReference[63]).Row).GetCell(new CellReference(cellReference[63]).Col).SetCellValue(Convert.ToDouble(report.CronogramaEtapa12));
                sheet.GetRow(new CellReference(cellReference[64]).Row).GetCell(new CellReference(cellReference[64]).Col).SetCellValue(Convert.ToDouble(report.CronogramaEtapa13));
                sheet.GetRow(new CellReference(cellReference[65]).Row).GetCell(new CellReference(cellReference[65]).Col).SetCellValue(Convert.ToDouble(report.CronogramaEtapa14));
                sheet.GetRow(new CellReference(cellReference[66]).Row).GetCell(new CellReference(cellReference[66]).Col).SetCellValue(Convert.ToDouble(report.CronogramaEtapa15));
                sheet.GetRow(new CellReference(cellReference[67]).Row).GetCell(new CellReference(cellReference[67]).Col).SetCellValue(Convert.ToDouble(report.CronogramaEtapa16));
                sheet.GetRow(new CellReference(cellReference[68]).Row).GetCell(new CellReference(cellReference[68]).Col).SetCellValue(Convert.ToDouble(report.CronogramaEtapa17));
                sheet.GetRow(new CellReference(cellReference[69]).Row).GetCell(new CellReference(cellReference[69]).Col).SetCellValue(Convert.ToDouble(report.CronogramaEtapa18));
                sheet.GetRow(new CellReference(cellReference[70]).Row).GetCell(new CellReference(cellReference[70]).Col).SetCellValue(Convert.ToDouble(report.CronogramaEtapa19));
                sheet.GetRow(new CellReference(cellReference[71]).Row).GetCell(new CellReference(cellReference[71]).Col).SetCellValue(Convert.ToDouble(report.CronogramaEtapa20));
                sheet.GetRow(new CellReference(cellReference[72]).Row).GetCell(new CellReference(cellReference[72]).Col).SetCellValue(Convert.ToDouble(report.CronogramaEtapa21));
                sheet.GetRow(new CellReference(cellReference[73]).Row).GetCell(new CellReference(cellReference[73]).Col).SetCellValue(Convert.ToDouble(report.CronogramaEtapa22));
                sheet.GetRow(new CellReference(cellReference[74]).Row).GetCell(new CellReference(cellReference[74]).Col).SetCellValue(Convert.ToDouble(report.CronogramaEtapa23));
                sheet.GetRow(new CellReference(cellReference[75]).Row).GetCell(new CellReference(cellReference[75]).Col).SetCellValue(Convert.ToDouble(report.CronogramaEtapa24));
                sheet.GetRow(new CellReference(cellReference[76]).Row).GetCell(new CellReference(cellReference[76]).Col).SetCellValue(Convert.ToDouble(report.CronogramaEtapa25));
                sheet.GetRow(new CellReference(cellReference[77]).Row).GetCell(new CellReference(cellReference[77]).Col).SetCellValue(Convert.ToDouble(report.CronogramaEtapa26));
                sheet.GetRow(new CellReference(cellReference[78]).Row).GetCell(new CellReference(cellReference[78]).Col).SetCellValue(Convert.ToDouble(report.CronogramaEtapa27));
                sheet.GetRow(new CellReference(cellReference[79]).Row).GetCell(new CellReference(cellReference[79]).Col).SetCellValue(Convert.ToDouble(report.CronogramaEtapa28));
                sheet.GetRow(new CellReference(cellReference[80]).Row).GetCell(new CellReference(cellReference[80]).Col).SetCellValue(Convert.ToDouble(report.CronogramaEtapa29));
                sheet.GetRow(new CellReference(cellReference[81]).Row).GetCell(new CellReference(cellReference[81]).Col).SetCellValue(Convert.ToDouble(report.CronogramaEtapa30));


                using (FileStream arquivoRAE = new FileStream(pathDestin, FileMode.Create, FileAccess.Write))
                {
                    wbook.ForceFormulaRecalculation = true;
                    wbook.Write(arquivoRAE);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}