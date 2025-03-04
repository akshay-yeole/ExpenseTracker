import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AccountSummaryComponent } from './account-summary/account-summary.component';
import { ExpenseListComponent } from './expense-list/expense-list.component';

const routes: Routes = [
  {
    path: 'expense-list',
    component: ExpenseListComponent
  },
  {
    path: '',
    redirectTo: 'account-summary',
    pathMatch: 'full'
  },
  {
    path: 'account-summary',
    component: AccountSummaryComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
