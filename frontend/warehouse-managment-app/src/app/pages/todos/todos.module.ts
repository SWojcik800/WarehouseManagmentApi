import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { TodosRoutingModule } from './todos-routing.module';
import { CustomTableModule } from 'src/app/shared';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatMenuModule } from '@angular/material/menu';
import { TodosTableComponent } from './todos-table/todos-table.component';


@NgModule({
  declarations: [
    TodosTableComponent
  ],
  imports: [
    CommonModule,
    TodosRoutingModule,
    CustomTableModule,
    MatButtonModule,
    MatIconModule,
    MatMenuModule
  ]
})
export class TodosModule { }
