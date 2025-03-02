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
  expenses: Expense[] =[];
  totalExpense: number = 0;
  newExpense: Expense = {
    amount: 0,
    expenseName: '',
    id: 0,
    transactionDate: new Date(),
  };

  constructor(
    private accountSummaryService: AccountSummaryService,
    private expenseService: ExpenseService
  ) {}

  ngOnInit(): void {
    this.accountSummaryService
      .getAccountSummary()
      .subscribe((accountSummary) => {
        this.accountSummary = accountSummary;
      });

    this.loadExpenses();
  }

  loadExpenses() {
    this.expenseService.getAllExpenses().subscribe((data) => {
      this.expenses = data || []; 
      this.calculateTotalExpense(); 
    });
  }

  calculateTotalExpense() {
    this.totalExpense = this.expenses.reduce((sum, e) => sum + e.amount, 0);
  }

  addExpense() {
    this.expenseService.addExpense(this.newExpense).subscribe();
  }
}
