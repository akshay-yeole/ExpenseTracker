import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Account } from '../models/account.model';

@Injectable({
  providedIn: 'root'
})
export class AccountSummaryService {

  baseApiUrl = 'https://localhost:5000/api';

  constructor(private client: HttpClient) { }

  getAccountSummary() : Observable<Account>{
    return this.client.get<Account>(`${this.baseApiUrl}/Accounts/CurrentBalance`);
  }

}
