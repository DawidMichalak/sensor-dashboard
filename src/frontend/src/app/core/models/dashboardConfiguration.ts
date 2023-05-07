export interface CardConfiguration {
  id: string;
  name: string;
  sensorId: number;
}

export interface DashboardConfiguration {
  id: string;
  configurationItems: CardConfiguration[];
}
