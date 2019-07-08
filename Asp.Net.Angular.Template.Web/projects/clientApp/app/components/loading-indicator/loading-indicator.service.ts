import { BehaviorSubject, Observable } from "rxjs";

export class LoadingIndicatorService {

    private isLoading: boolean;
    private showLoadingSub: BehaviorSubject<boolean> = new BehaviorSubject(this.isLoading);
    isLoading$: Observable<boolean> = this.showLoadingSub.asObservable();

    showLoading() {
        this.isLoading = true;
        this.showLoadingSub.next(this.isLoading);
    }

    hideLoading() {

        this.isLoading = false;
        this.showLoadingSub.next(this.isLoading);
    }

}