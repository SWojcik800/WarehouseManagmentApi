import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TodosTableComponent } from './todos-table/todos-table.component';

const routes: Routes = [{
  path: '',
  component: TodosTableComponent
}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class TodosRoutingModule { }
