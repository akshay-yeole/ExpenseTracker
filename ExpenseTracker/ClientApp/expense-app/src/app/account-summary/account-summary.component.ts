import { Component, OnInit } from '@angular/core';
import { Account } from '../models/account.model';
import { AccountSummaryService } from '../services/account-summary.service';
import { ExpenseService } from '../services/expense.service';
import { Expense } from '../models/expense.model';

@Component({
  selector: 'app-account-summary',
  templateUrl: './account-summary.component.html',
  styleUrls: ['./account-summary.component.css'],
})
export class AccountSummaryComponent implements OnInit {
  accountSummary!: Account;
  expenses!: Expense[];
  totalExpenses: number = 0;
  newExpense :Expense = { amount: 0, expenseName: '', id: 0, transactionDate: new Date()};

  constructor(private accountSummaryService: AccountSummaryService, private expenseService : ExpenseService) {}

  ngOnInit(): void {
    this.accountSummaryService
      .getAccountSummary()
      .subscribe((accountSummary) => {
        this.accountSummary = accountSummary;
      });

      this.expenseService.getAllExpenses().subscribe((expenses) => {
        this.expenses = expenses;
      });
  }

  addExpense(){}
}
