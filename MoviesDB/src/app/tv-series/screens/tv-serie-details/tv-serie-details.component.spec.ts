import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TvSerieDetailsComponent } from './tv-serie-details.component';

describe('TvSerieDetailsComponent', () => {
  let component: TvSerieDetailsComponent;
  let fixture: ComponentFixture<TvSerieDetailsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TvSerieDetailsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TvSerieDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
