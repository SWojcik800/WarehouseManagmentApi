import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: '',
    loadChildren: () => import('./pages/products/products.module').then(m => m.ProductsModule)
  },
  {
    path: 'stock-levels',
    loadChildren: () => import('./pages/stock-levels/stock-levels.module').then(m => m.StockLevelsModule)
  },
  {
    path: 'todos',
    loadChildren: () => import('./pages/todos').then(m => m.TodosModule)
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
