import * as React from 'react';
import { useState, useEffect, useCallback } from 'react';
import {
  Grid,
  GridColumn,
  GridDataStateChangeEvent,
} from '@progress/kendo-react-grid';
import { State, DataResult, toDataSourceRequestString } from '@progress/kendo-data-query';
import axios from 'axios';
import "@progress/kendo-theme-default/dist/all.css"
const CustomCell = (props: any) => {
  return (
    <td {...props.tdProps}>
      <span style={{ color: 'crimson' }}>${props.dataItem[props.field]}</span>
    </td>
  );
};

const initialState: State = {
  take: 10,
  skip: 0,
  group: [],
};

export const GridComponent = () => {
  const [gridData, setGridData] = useState<DataResult>({ data: [], total: 0 });
  const [dataState, setDataState] = useState<State>(initialState);

  const fetchData = useCallback(async (state: State) => {
    try {
      const queryString = toDataSourceRequestString(state);
      const response = await axios.get<DataResult>(
        `https://localhost:7079/api/TestGrid/getProductsQuery?${queryString}`
      );
      setGridData(response.data);
    } catch (error) {
      console.error('Failed to fetch data:', error);
    }
  }, []);

  useEffect(() => {
    fetchData(dataState);
  }, [dataState, fetchData]);

  const handleDataStateChange = (event: GridDataStateChangeEvent) => {
    setDataState(event.dataState);
  };

  return (
    <Grid
      style={{ height: '520px' }}
      data={gridData}
      {...dataState}
      pageable
      sortable
      filterable
      groupable
      resizable
      navigatable
      onDataStateChange={handleDataStateChange}
      dataItemKey="Id"
    >
      <GridColumn field="id" title="ID" width="50px" />
      <GridColumn field="name" title="Name" width="300px" />
      <GridColumn field="price" title="Price" width="150px" filter="numeric" cell={CustomCell} />
      <GridColumn field="addedDate" title="Added Date" width="200px" />
      <GridColumn field="brand" title="Brand" width="200px" />
    </Grid>
  );
};
export default GridComponent;