import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { StockLevelsTableComponent } from './stock-levels-table/stock-levels-table.component';

const routes: Routes = [{
  path: '',
  component: StockLevelsTableComponent
}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class StockLevelsRoutingModule { }
