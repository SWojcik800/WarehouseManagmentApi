import { Component } from '@angular/core';
import { WebApiService } from '@core/web-api';
import { Observable } from 'rxjs';
import { TableChangedEvent } from 'src/app/shared/custom-table/components';

@Component({
  selector: 'app-todos-table',
  templateUrl: './todos-table.component.html',
  styleUrls: ['./todos-table.component.scss']
})
export class TodosTableComponent {  
  
  constructor(private _api: WebApiService) {

  }

  getData = (event: TableChangedEvent): Observable<any>  =>
    this._api.get('/todos');  


}
