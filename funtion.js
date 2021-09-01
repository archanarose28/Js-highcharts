fetch("./case1.json")
  .then((response) => response.json())
  .then((data) => {
    x_values = Object.keys(data);
    y_values = Object.values(data);

    Highcharts.chart("container", {
      chart: {
        type: "column",
      },
      title: {
        text: "Count by Authorized Cap",
      },
      xAxis: {
        title: {
          text: "BIN",
        },
        categories: x_values,
      },
      yAxis: {
        title: {
          text: "Count",
        },
      },
      series: [
        {
          data: y_values,
        },
      ],
    });
  });
fetch("./case2.json")
  .then((response) => response.json())
  .then((data) => {
    x_values = Object.keys(data);
    y_values = Object.values(data);

    Highcharts.chart("container1", {
      chart: {
        type: "bar",
      },
      title: {
        text: "Company Registration by Year (From 2000 to 2019)",
      },
      xAxis: {
        title: {
          text: "DATE_OF_REGISTRAION",
        },
        categories: x_values,
      },
      yAxis: {
        title: {
          text: "Count of the number of company registrations",
        },
      },
      series: [
        {
          data: y_values,
        },
      ],
    });
  });
fetch("./case3.json")
  .then((response) => response.json())
  .then((data) => {
    x_values = Object.keys(data);
    y_values = Object.values(data);
    Highcharts.chart("container2", {
      chart: {
        type: "bar",
      },
      title: {
        text: "Company Registration by principal business activity (for the year 2015)",
      },
      xAxis: {
        title: {
          text: "PRINCIPAL_BUSINESS_ACTIVITY",
        },
        categories: x_values,
      },
      yAxis: {
        title: {
          text: "Count",
        },
      },
      series: [
        {
          data: y_values,
        },
      ],
    });
  });

let dat1 = [],
  dat2 = [],
  dat3 = [],
  dat4 = [],
  dat5 = [],
  dat6 = [],
  dat7 = [],
  dat8 = [];
let case4Data = fetch("./case4.json");
//storing 8 needed strings
let str1 = "Agriculture, hunting and related service activities";
let str2 = "Hotels and restaurants";
let str3 = "Manufacture of food products and beverages";
let str4 = "Manufacture of chemicals and chemical products";
let str5 = "Manufacture of basic metals";
let str6 = "Real estate activities";
let str7 = "Fishing, aquaculture and service activities incidental to fishing";
let str8 = "Transport, storage and communications";
fetch("./case4.json")
  .then((response) => response.json())
  .then((data) => {
    let dict = data;
    console.log(dict);
    //storing count of str1 from year 2000 to 2007
    for (let i = 0, k = 2000; i < 8 && k < 2008; i++, k++) {
      dat1[i] = dict[k][str1]; //str1 count in dat1 to dat8
      if (dat1[i] == undefined) dat1[i] = 0; //initialize with 0 if undefined
    }
    console.log(dat1);
    //storing count of str2 from year 2000 to 2007
    for (let i = 0, k = 2000; i < 8 && k < 2008; i++, k++) {
      dat2[i] = dict[k][str2]; //str2 count in dat1 to dat8
      if (dat2[i] == undefined) dat2[i] = 0; //initialize with 0 if undefined
    }
    console.log(dat2);
    //storing count of str3 from year 2000 to 2007
    for (let i = 0, k = 2000; i < 8 && k < 2008; i++, k++) {
      dat3[i] = dict[k][str3]; //str3 count in dat1 to dat8
      if (dat3[i] == undefined) dat3[i] = 0; //initialize with 0 if undefined
    }
    console.log(dat3);
    //storing count of str4 from year 2000 to 2007
    for (let i = 0, k = 2000; i < 8 && k < 2008; i++, k++) {
      dat4[i] = dict[k][str4]; //str4 count in dat1 to dat8
      if (dat4[i] == undefined) dat4[i] = 0; //initialize with 0 if undefined
    }
    console.log(dat4);
    //storing count of str5 from year 2000 to 2007
    for (let i = 0, k = 2000; i < 8 && k < 2008; i++, k++) {
      dat5[i] = dict[k][str5]; //str5 count in dat1 to dat8
      if (dat5[i] == undefined) dat5[i] = 0; //initialize with 0 if undefined
    }
    console.log(dat5);
    //storing count of str6 from year 2000 to 2007
    for (let i = 0, k = 2000; i < 8 && k < 2008; i++, k++) {
      dat6[i] = dict[k][str6]; //str6 count in dat1 to dat8
      if (dat6[i] == undefined) dat6[i] = 0; //initialize with 0 if undefined
    }
    console.log(dat6);
    //storing count of str7 from year 2000 to 2007
    for (let i = 0, k = 2000; i < 8 && k < 2008; i++, k++) {
      dat7[i] = dict[k][str7]; //str7 count in dat1 to dat8
      if (dat7[i] == undefined) dat7[i] = 0; //initialize with 0 if undefined
    }
    console.log(dat7);
    //storing count of str8 from year 2000 to 2007
    for (let i = 0, k = 2000; i < 8 && k < 2008; i++, k++) {
      dat8[i] = dict[k][str8]; //str8 count in dat1 to dat8
      if (dat8[i] == undefined) dat8[i] = 0; //initialize with 0 if undefined
    }
    console.log(dat8);

    Highcharts.chart("container5", {
      title: {
        text: "GROUPED AGGREGATION: Principal Business Activity from the years 2000-2007",
      },

      subtitle: {
        text: "",
      },

      yAxis: {
        title: {
          text: "COUNT",
        },
      },

      xAxis: {
        accessibility: {
          rangeDescription: "Range: 2000 to 2007",
        },
      },

      legend: {
        layout: "vertical",
        align: "right",
        verticalAlign: "middle",
      },

      plotOptions: {
        series: {
          label: {
            connectorAllowed: false,
          },
          pointStart: 2000,
        },
      },

      series: [
        {
          name: str1,
          data: dat1,
        },
        {
          name: str2,
          data: dat2,
        },
        {
          name: str3,
          data: dat3,
        },
        {
          name: str4,
          data: dat4,
        },
        {
          name: str5,
          data: dat5,
        },
        {
          name: str6,
          data: dat6,
        },
        {
          name: str7,
          data: dat7,
        },
        {
          name: str8,
          data: dat8,
        },
      ],

      responsive: {
        rules: [
          {
            condition: {
              maxWidth: 500,
            },
            chartOptions: {
              legend: {
                layout: "horizontal",
                align: "center",
                verticalAlign: "bottom",
              },
            },
          },
        ],
      },
    });
  });
