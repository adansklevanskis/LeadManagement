import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LeadsComponent } from './leads/leads.component';

const routes: Routes = [
  { path: 'leads', component: LeadsComponent },
  { path: '', redirectTo: '/leads', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }