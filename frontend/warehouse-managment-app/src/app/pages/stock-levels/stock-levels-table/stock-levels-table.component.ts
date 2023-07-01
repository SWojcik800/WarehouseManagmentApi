import { Component, ViewChild } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { WebApiService } from '@core/web-api';
import { UntilDestroy, untilDestroyed } from '@ngneat/until-destroy';
import { FormlyFieldConfig } from '@ngx-formly/core';
import { Observable } from 'rxjs';
import { CustomTableComponent, TableChangedEvent } from 'src/app/shared/custom-table/components';

@UntilDestroy()
@Component({
  selector: 'app-stock-levels-table',
  templateUrl: './stock-levels-table.component.html',
  styleUrls: ['./stock-levels-table.component.scss']
})
export class StockLevelsTableComponent {
  @ViewChild(CustomTableComponent) table!: CustomTableComponent; 

  form = new FormGroup({});
  updateFormGroup = new FormGroup({});
  fields: FormlyFieldConfig[] = [
    {
      key: 'productId',
      type: 'number',
      props: {
        label: 'ProductId',
        placeholder: 'ProductId',
        required: true,
      }
    },
    {
      key: 'productsInStock',
      type: 'number',
      props: {
        label: 'ProductsInStock',
        placeholder: 'ProductsInStock',
        required: true,
      }
    }
  ];


  constructor(private _api: WebApiService, protected dialog: MatDialog) {
  }

  getData = (event: TableChangedEvent): Observable<any>  =>
    this._api.get('/stocklevel', { offset: (event.paging.pageIndex-1)*event.paging.pageSize ,limit: event.paging.pageSize } );
    actionTriggered = (x: any) => console.log(x);

  getTotalCountFunc = (x: any) => x.totalCount;
  getItemsFunc = (x: any) => x.items;

  onSubmit(): void {

    if(this.form.valid)
    {
      this._api.put('/stocklevel', this.form.value)
      .pipe(
        untilDestroyed(this)
      ).subscribe(() => this.table.refreshTable());
    }

  }

  update(): void {
    if(this.form.valid)
    {
      this._api.put('/stocklevel', this.updateFormGroup.value)
      .pipe(
        untilDestroyed(this)
      ).subscribe(() => this.table.refreshTable());
    }
  }
}
