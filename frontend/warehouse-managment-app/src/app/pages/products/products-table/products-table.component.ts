import { Component, ViewChild } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { WebApiService } from '@core/web-api';
import { UntilDestroy, untilDestroyed } from '@ngneat/until-destroy';
import { FormlyFieldConfig } from '@ngx-formly/core';
import { Observable } from 'rxjs';
import { CustomTableComponent, TableChangedEvent } from 'src/app/shared/custom-table/components';

@UntilDestroy()
@Component({
  selector: 'app-products-table',
  templateUrl: './products-table.component.html',
  styleUrls: ['./products-table.component.scss']
})
export class ProductsTableComponent {

  @ViewChild(CustomTableComponent) table!: CustomTableComponent; 
  form = new FormGroup({});
  updateFormGroup = new FormGroup({
    id: new FormControl(),
    name: new FormControl(''),
    description: new FormControl(''),
    manufacturer: new FormControl('')
  });
  fields: FormlyFieldConfig[] = [
    {
      key: 'name',
      type: 'input',
      props: {
        label: 'Name',
        placeholder: 'Name',
        required: true,
      }
    },
    {
      key: 'description',
      type: 'input',
      props: {
        label: 'Description',
        placeholder: 'Description',
        required: true,
      }
    },
    {
      key: 'manufacturer',
      type: 'input',
      props: {
        label: 'Manufacturer',
        placeholder: 'Manufacturer',
        required: true,
      }
    }
  ];

  constructor(private _api: WebApiService, protected dialog: MatDialog) {
  }

  getData = (event: TableChangedEvent): Observable<any>  =>
    this._api.get('/products', { offset: (event.paging.pageIndex-1)*event.paging.pageSize ,limit: event.paging.pageSize } );
    actionTriggered = (x: any) => console.log(x);

  getTotalCountFunc = (x: any) => x.totalCount;
  getItemsFunc = (x: any) => x.items;

  deleteProduct(id: number)
  {
    this._api.delete(`/products/?id=${id}`, id)
    .pipe(
      untilDestroyed(this)
    ).subscribe(() => this.table.refreshTable());
  }

  update(id: number): void
  {
    if(this.form.valid)
    {
      let updateRequest: any = this.updateFormGroup.value;
      updateRequest.id = id;
      this._api.patch('/products', updateRequest)
      .pipe(
        untilDestroyed(this)
      ).subscribe(() => this.table.refreshTable());   
    }
  }

  onSubmit(): void
  {
    if(this.form.valid)
    {
      this._api.post('/products', this.form.value)
      .pipe(
        untilDestroyed(this)
      ).subscribe(() => this.table.refreshTable());
    }
  }
    

}
