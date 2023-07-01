import { Component } from '@angular/core';
import { WebApiService } from '@core/web-api';
import { Observable } from 'rxjs';
import { TableChangedEvent } from 'src/app/shared/custom-table/components';

@Component({
  selector: 'app-stock-levels-table',
  templateUrl: './stock-levels-table.component.html',
  styleUrls: ['./stock-levels-table.component.scss']
})
export class StockLevelsTableComponent {
  constructor(private _api: WebApiService) {
  }

  getData = (event: TableChangedEvent): Observable<any>  =>
    this._api.get('/stocklevel', { offset: (event.paging.pageIndex-1)*event.paging.pageSize ,limit: event.paging.pageSize } );
    actionTriggered = (x: any) => console.log(x);

  getTotalCountFunc = (x: any) => x.totalCount;
  getItemsFunc = (x: any) => x.items;
}
