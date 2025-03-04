import { Component, OnInit } from '@angular/core';
import { Account } from '../models/account.model';
import { AccountSummaryService } from '../services/account-summary.service';
import { ExpenseService } from '../services/expense.service';
import { Expense } from '../models/expense.model';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-account-summary',
  templateUrl: './account-summary.component.html',
  styleUrls: ['./account-summary.component.css'],
})
export class AccountSummaryComponent implements OnInit {
  accountSummary!: Account;
  addIncome: Account = {
    id: 0,
    balance: 0,
  };
  expenses$ : Observable<Expense[]> = this.expenseService.getAllExpenses();
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

    this.expenses$.subscribe((expenses) => {
      this.totalExpense = expenses.reduce((sum, expense) => sum + expense.amount, 0);
    });
  }

  addExpense() {
    this.expenseService.addExpense(this.newExpense).subscribe(() => {
      this.expenses$ = this.expenseService.getAllExpenses();
      this.expenses$.subscribe((expenses) => {
        this.totalExpense = expenses.reduce((sum, expense) => sum + expense.amount, 0);
      });
    });
  }
  
  addBalance(){
    this.accountSummaryService.addIncome(this.addIncome).subscribe(res=>{this.addIncome.balance = 0;});  
  }
}
