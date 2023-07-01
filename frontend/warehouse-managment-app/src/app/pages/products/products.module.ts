import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ProductsRoutingModule } from './products-routing.module';
import { ProductsTableComponent } from './products-table/products-table.component';
import { CustomTableModule } from 'src/app/shared';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatMenuModule } from '@angular/material/menu';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatDialogModule } from '@angular/material/dialog';
import { FormlyModule } from '@ngx-formly/core';
import { FormlyMaterialModule } from '@ngx-formly/material';
import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    ProductsTableComponent
  ],
  imports: [
    CommonModule,
    ProductsRoutingModule,
    CustomTableModule,
    MatButtonModule,
    MatIconModule,
    MatMenuModule,
    ReactiveFormsModule,
    FormlyMaterialModule,
    FormlyModule,
    MatDialogModule,
    MatFormFieldModule
  ]
})
export class ProductsModule { }
