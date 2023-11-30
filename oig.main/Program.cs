using oig.domain.source.faker.Entities;
using oig.pdf.Implementation;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using QuestPDF.Previewer;
using System.Diagnostics;
using System.Reflection.Metadata;

QuestPDF.Settings.License = LicenseType.Community;

OrderFaker.LineItemCount = 45;

var invoice = InvoiceFaker.Generate();

var directoryPath = @"C:\Users\bisha\Desktop";
var fileName = @"invoice.pdf";
var fullPath = Path.Combine(directoryPath, fileName);

InvoiceDocument doc = new(invoice);

doc.ShowInPreviewer();

doc.GeneratePdf(fullPath);

Process.Start("explorer.exe", fullPath);