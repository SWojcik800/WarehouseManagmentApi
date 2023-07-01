import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { StockLevelsRoutingModule } from './stock-levels-routing.module';
import { MatMenuModule } from '@angular/material/menu';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { CustomTableModule } from 'src/app/shared';
import { StockLevelsTableComponent } from './stock-levels-table/stock-levels-table.component';
import { ReactiveFormsModule } from '@angular/forms';
import { FormlyMaterialModule } from '@ngx-formly/material';
import { FormlyModule } from '@ngx-formly/core';
import { MatDialogModule } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';


@NgModule({
  declarations: [
    StockLevelsTableComponent
  ],
  imports: [
    CommonModule,
    CustomTableModule,
    MatButtonModule,
    MatIconModule,
    MatMenuModule,
    StockLevelsRoutingModule,
    ReactiveFormsModule,
    FormlyMaterialModule,
    FormlyModule,
    MatDialogModule,
    MatFormFieldModule
  ]
})
export class StockLevelsModule { }
