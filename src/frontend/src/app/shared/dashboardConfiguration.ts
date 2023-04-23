export interface CardConfiguration {
  name: string;
  sensorId: number;
}

export interface DashboardConfiguration {
  configurationItems: CardConfiguration[];
}
