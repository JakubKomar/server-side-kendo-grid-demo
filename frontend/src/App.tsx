import * as React from 'react';
import { useState, useEffect } from 'react';
import {
  Grid,
  GridColumn,
  GridGroupChangeEvent,
  GridGroupExpandChangeEvent
} from '@progress/kendo-react-grid';
import { GroupExpandDescriptor } from '@progress/kendo-react-data-tools';
import {
  groupBy,
  GroupDescriptor,
  State,
  process,
  toDataSourceRequestString
} from '@progress/kendo-data-query';
import axios from 'axios';
import "@progress/kendo-theme-default/dist/all.css";
import { group } from 'console';

const CustomCell = (props: any) => {
  return (
    <td {...props.tdProps}>
      <span style={{ color: 'crimson' }}>${props.dataItem[props.field]}</span>
    </td>
  );
};

const initialState: State = {
  skip: 0,
  take: 10,
};

export const GridComponent = () => {
  const [products, setProducts] = useState<[]>([]);
  const [dataState, setDataState] = useState<State>(initialState);

  useEffect(() => {
    const fetchProducts = async () => {
      try {
        const queryString = toDataSourceRequestString(dataState);
        const response = await axios.get(`https://localhost:7079/api/ProductContrroler?${queryString}`);
        setProducts(response.data);
      } catch (error) {
        console.error("Error fetching products:", error);
      }
    };

    fetchProducts();
  }, [dataState]);

  const handleDataStateChange = (event: any) => {
    setDataState(event.dataState);
  };

  return (
    <Grid
      data={products}
      {...dataState}
      pageable={{
        buttonCount: 4,
        pageSizes: [5, 10, 15]
      }}
      sortable
      filterable
      onDataStateChange={handleDataStateChange}

      dataItemKey="id"
      resizable
      navigatable
    >
      <GridColumn field="id" title="ID" width="50px" filter="numeric" />
      <GridColumn field="name" title="Name" width="300px" />
      <GridColumn field="price" title="Price" width="150px" filter="numeric" />
      <GridColumn field="addedDate" title="Added Date" format="{0:dd.MM.yy}" filter="date" width="200px" />
      <GridColumn field="brand" title="Brand" width="200px" />
    </Grid>
  );
};

export default GridComponent;
