import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Expense } from '../models/expense.model';

@Injectable({
  providedIn: 'root'
})
export class ExpenseService {
  baseApiUrl = 'https://localhost:5000/api';

  constructor(private client: HttpClient) { }

  getAllExpenses() : Observable<Expense[]>{
    return this.client.get<Expense[]>(`${this.baseApiUrl}/Expenses/GetAllExpenses`);
  }
}
