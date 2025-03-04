import { Component } from '@angular/core';
import { Observable } from 'rxjs';
import { Expense } from '../models/expense.model';
import { ExpenseService } from '../services/expense.service';

@Component({
  selector: 'app-expense-list',
  templateUrl: './expense-list.component.html',
  styleUrls: ['./expense-list.component.css']
})
export class ExpenseListComponent {
  expenses$ : Observable<Expense[]> = this.expenseService.getAllExpenses();

  constructor(private expenseService : ExpenseService) { }

  deleteExpense(expense: any) {}

}
