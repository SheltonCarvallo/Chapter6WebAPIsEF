using Azure.Core;
using EFCoreData.Data;
using Invoice.Domain.Models;
using InvoicePeople.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Linq;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace InvoicePeople.Services
{
    public class InvoiceService : IInvoice
    {
        readonly InvoiceDbContext _context;

        public InvoiceService(InvoiceDbContext context)
        {
            _context = context; 
        }

        //just filtering
        /*public async Task<ActionResult<IEnumerable<InvoiceModel>>> GetInvoices(InvoiceStatusModel? status)
        {
            return await _context.Invoices.Where(invoice =>  status == null || invoice.Status == status).ToListAsync();
        }*/

        public async Task<IEnumerable<InvoiceModel>> GetInvoices(InvoiceStatusModel? status, int page = 1, int pageSize = 10)
        {

            /*IQueryable<InvoiceModel> query =  _context.Invoices.Where(invoice => status == null || invoice.Status == status)
                                                                    .OrderByDescending(invoice => invoice.InvoiceDate)           //If I am not mistaken OrderByDsecendig put the greatest value in the top and OrderBy works the other way around
                                                                    .Skip((page - 1) * pageSize)
                                                                    .Take(pageSize);

            The response contains a list of invoices.But the InvoiceItems property is empty.This is because the InvoiceItems property is a collection navigation property. 
             By default, EF Core does not include dependent entities in the query result, so you need to explicitly include these in the query result.*/



            /*IQueryable <InvoiceModel> query = _context.Invoices.Include(invoice => invoice.InvoiceItems) //we use the Include method to include dependent entities in the query result
                                                                    .Where(invoice => status == null || invoice.Status == status)
                                                                    .OrderByDescending(invoice => invoice.InvoiceDate)    
                                                                    .Skip((page - 1) * pageSize)
                                                                    .Take(pageSize);*/

            /*The Include() method is a convenient way to include dependent entities.However, it may cause performance issues when the collection of dependent entities is large.
              For example, a post may have hundreds or thousands of comments.It is not a good idea to include all comments in the query result for a list page.
              In this case, it is not necessary to include dependent entities in the query*/

            IQueryable<InvoiceModel> query = _context.Invoices.Include(invoice => invoice.InvoiceItems)
                                                              .Where(invoice => status == null || invoice.Status == status)
                                                              .OrderByDescending(invoice => invoice.InvoiceDate)
                                                              .Skip((page - 1) * pageSize)
                                                              .Take(pageSize)
                                                              .AsSplitQuery();

            return await query.ToListAsync();

        }
            public async Task<InvoiceModel> GetInvoice(Guid id)
            {
                InvoiceModel? invoice;
                try
                {
                    bool existsId = await _context.Invoices.AnyAsync(invoice => invoice.id == id);
                    if (existsId)
                    {
                    //invoice = await _context.Invoices.FindAsync(id);

                    invoice = await _context.Invoices.Include(invoice => invoice.InvoiceItems)
                                                     .SingleOrDefaultAsync(invoice => invoice.id == id);   

                    }
                    else
                    {
                        return new InvoiceModel { };
                    }
            }
            catch (Exception)
            {

                throw;
            }

            return invoice!;
        }

        public async Task PostInvoice(InvoiceModel invoice)
        {
            try
            {
                bool isRegistered = await _context.Invoices.AnyAsync(inv => inv.id == invoice.id); 
                if (isRegistered)
                {
                    return;
                }
                _context.Invoices.Add(invoice);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task PutInvoice(Guid id, InvoiceModel invoice)
        {
            try
            {
                InvoiceModel? invoiceToUpdate = await _context.Invoices.FindAsync(id);
                if (invoiceToUpdate is null)
                {
                    return;
                }
                invoiceToUpdate.InvoiceNumber = invoice.InvoiceNumber;
                invoiceToUpdate.ContactName = invoice.ContactName;
                invoiceToUpdate.Description = invoice.Description;
                invoiceToUpdate.Amount = invoice.Amount;
                invoiceToUpdate.InvoiceDate = invoice.InvoiceDate;
                invoiceToUpdate.DueDate = invoice.DueDate;
                invoice.Status = invoice.Status;
                await _context.SaveChangesAsync();
                
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<bool> DeleteInvoice(Guid id)
        {
            InvoiceModel? invoiceToDelete = await _context.Invoices.FindAsync(id);
            if (invoiceToDelete is null)
            {
                return false;
            }
            invoiceToDelete.Status = 0;
            await _context.SaveChangesAsync();
            return true;
        }


    }
}
