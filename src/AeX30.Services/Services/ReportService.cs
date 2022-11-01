﻿using AeX30.Domain.Entities;
using AeX30.Infra.Repository;
using System.IO;

namespace AeX30.Services.Services
{
    public class ReportService
    {
        public static bool SetReport(string templatePath, string saveAsPath, Report report)
        {
            if (IsValid(templatePath))
            {
                ReportRepository.SetReport(templatePath, saveAsPath, report);
                return true;
            }
            else
                return false;
        }

        private static bool IsValid(string filePath)
        {
            string footer = ReportRepository.GetLeftFooter(filePath);
            string sheetName = ReportRepository.GetSheetName(filePath);

            bool fileExists = File.Exists(filePath);
            bool sheetNameIsValid = sheetName == "RAE";
            bool footerIsValid = footer != "" || footer != null;

            return fileExists && sheetNameIsValid && footerIsValid;
        }

    }
}






