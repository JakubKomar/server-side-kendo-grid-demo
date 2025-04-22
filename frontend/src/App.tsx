import { useState, useEffect } from 'react';
import { Grid, GridColumn } from '@progress/kendo-react-grid';
import { State, toDataSourceRequestString } from '@progress/kendo-data-query';
import axios from 'axios';
import "@progress/kendo-theme-default/dist/all.css";

export const GridComponent = () => {
  const [products, setProducts] = useState<[]>([]);
  const [dataState, setDataState] = useState<State>({ skip: 0, take: 10, });

  useEffect(() => {
    const fetchProducts = async () => {
      try {
        const urlBase = "https://localhost:7079/api/Product";

        const queryString = toDataSourceRequestString(dataState);
        const response = await axios.get(`${urlBase}?${queryString}`);

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
      pageable={{ buttonCount: 4, pageSizes: [5, 10, 15] }}
      sortable
      filterable
      resizable
      navigatable

      onDataStateChange={handleDataStateChange}
      dataItemKey="id"
    >
      <GridColumn field="id" title="ID" filter="numeric" width="250px" />
      <GridColumn field="name" title="Name" width="250px" />
      <GridColumn field="price" title="Price" filter="numeric" format="{0:d} $" width="250px" />
      <GridColumn field="addedDate" title="Added Date" filter="date" format="{0:dd.MM.yy}" width="250px" />
      <GridColumn field="brand" title="Brand" width="250px" />
    </Grid>
  );
};

export default GridComponent;
