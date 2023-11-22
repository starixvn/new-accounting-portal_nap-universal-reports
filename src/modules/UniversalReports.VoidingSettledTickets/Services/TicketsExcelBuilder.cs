using AutoMapper;
using Epplus.Mapper.Extensions;
using OfficeOpenXml;
using System.Collections.Generic;
using System.IO;
using UniversalReports.VoidingSettledTickets.Models;

namespace UniversalReports.VoidingSettledTickets.Services
{
    using Configurations;

    public interface TicketsExcelBuilder
    {
        ExcelPackage Build(string productName, VoidTicketModel tickets);
    }

    public class TicketsExcelBuilderImp : TicketsExcelBuilder
    {
        private readonly ConfigurationService configurationService;

        private ExcelWorksheet productActual;

        private ExcelWorksheet totalSheet;

        private const int StartRowIndex = 4;

        private ExcelPackage ExcelPackage { get; set; }

        public TicketsExcelBuilderImp(ConfigurationService configurationService)
        {
            this.configurationService = configurationService;
        }

        public ExcelPackage Build(string productName, VoidTicketModel tickets)
        {
            LoadTemplate();
            BuilTitle(productName);
            BuildRow(tickets);
            BuildTotal(tickets);
            ClearTemplate();
            return ExcelPackage;
        }

        private void BuildRow(VoidTicketModel tickets)
        {
            var ticketsExcel = Mapper.Map<List<TicketExcelModel>>(tickets.Tickets);
            productActual.ApplyVertical(ticketsExcel, StartRowIndex);
        }

        private void BuildTotal(VoidTicketModel tickets)
        {
            var totalExcel = Mapper.Map<TicketExcelModel>(tickets.Total);
            var totalIndex = StartRowIndex + tickets.Tickets.Count;
            productActual.ApplyModel(totalSheet, totalExcel, totalIndex);
            productActual.Cells[$"A{totalIndex}:D{totalIndex}"].Merge = true;
            productActual.Cells[$"A{totalIndex}:D{totalIndex}"].Value = "Total";
        }

        private void LoadTemplate()
        {
            var templateAbsolutelyPath = $"{configurationService.CurrentDirectory}\\ExcelTemplate\\VoidingSettledTicket\\Ticket.xlsx";
            using (var stream = new FileStream(templateAbsolutelyPath, FileMode.Open, FileAccess.Read))
            {
                ExcelPackage = new ExcelPackage(stream);
                productActual = ExcelPackage.Workbook.Worksheets.Copy("ItemTemplate", "Voided Tickets");
                totalSheet = ExcelPackage.Workbook.Worksheets["TotalTemplate"];
            }
        }

        private void ClearTemplate()
        {
            ExcelPackage.Workbook.Worksheets.Delete("ItemTemplate");
            ExcelPackage.Workbook.Worksheets.Delete("TotalTemplate");
        }

        private void BuilTitle(string productName)
        {
            productActual.Cells["A1:F1"].Value = $"Main > {productName}";
        }
    }
}