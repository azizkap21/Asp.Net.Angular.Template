import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { LoadingIndicatorService } from './loading-indicator.service';

@Component({
    selector: 'app-loading-indicator',
    templateUrl: './loading-indicator.component.html',
    styleUrls: ['./loading-indicator.component.scss']
})
export class LoadingIndicatorComponent implements OnInit {
    public loading$: Observable<boolean>;

    constructor(private loadingService: LoadingIndicatorService) { }

    ngOnInit() {

        this.loading$ = this.loadingService.isLoading$;

    }

}
