import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AccountSummaryComponent } from './account-summary/account-summary.component';

const routes: Routes = [
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
