using oig.domain.source.faker.Entities;
using oig.pdf.Implementation;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using System.Diagnostics;

QuestPDF.Settings.License = LicenseType.Community;

OrderFaker.LineItemCount = 6;

var invoice = InvoiceFaker.Generate();

var directoryPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
var fileName = @"invoice.pdf";

var fullPath = Path.Combine(directoryPath, fileName);

InvoiceDocument doc = new(invoice);

// For Debug purpose
//doc.ShowInPreviewer();

doc.GeneratePdf(fullPath);

Process.Start("explorer.exe", fullPath);