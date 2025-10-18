"use strict";
$(function () {
  barChart();
  stackedBarChart();
  stackedAreaChart();
  barChartLabel();
  lineChart();
  pieChart();
  doughnutChart();
  nightingaleChart();
  candlestickChart();
  radarChart();
});

function barChart() {
  var dom = document.getElementById("echarts_bar");
  var myChart = echarts.init(dom, null, {
    renderer: "canvas",
    useDirtyRect: false,
  });
  var app = {};

  var option;

  option = {
    xAxis: {
      type: "category",
      data: ["دوشنبه", "سه‌شنبه", "چهارشنبه", "پنج‌شنبه", "جمعه", "شنبه", "یک‌شنبه"],
      axisLabel: {
        color: "#9aa0ac",
      },
    },
    yAxis: {
      type: "value",
      axisLabel: {
        color: "#9aa0ac",
      },
    },
    series: [
      {
        data: [120, 200, 150, 80, 70, 110, 130],
        type: "bar",
      },
    ],
  };

  if (option && typeof option === "object") {
    myChart.setOption(option);
  }

  window.addEventListener("resize", myChart.resize);
}

function stackedBarChart() {
  var dom = document.getElementById("stacked_bar");
  var myChart = echarts.init(dom, null, {
    renderer: "canvas",
    useDirtyRect: false,
  });
  var app = {};

  var option;

  var series = [
    {
      data: [120, 200, 150, 80, 70, 110, 130],
      type: "bar",
      stack: "a",
      name: "a",
    },
    {
      data: [10, 46, 64, "-", 0, "-", 0],
      type: "bar",
      stack: "a",
      name: "b",
    },
    {
      data: [30, "-", 0, 20, 10, "-", 0],
      type: "bar",
      stack: "a",
      name: "c",
    },
    {
      data: [30, "-", 0, 20, 10, "-", 0],
      type: "bar",
      stack: "b",
      name: "d",
    },
    {
      data: [10, 20, 150, 0, "-", 50, 10],
      type: "bar",
      stack: "b",
      name: "e",
    },
  ];
  const stackInfo = {};
  for (let i = 0; i < series[0].data.length; ++i) {
    for (let j = 0; j < series.length; ++j) {
      const stackName = series[j].stack;
      if (!stackName) {
        continue;
      }
      if (!stackInfo[stackName]) {
        stackInfo[stackName] = {
          stackStart: [],
          stackEnd: [],
        };
      }
      const info = stackInfo[stackName];
      const data = series[j].data[i];
      if (data && data !== "-") {
        if (info.stackStart[i] == null) {
          info.stackStart[i] = j;
        }
        info.stackEnd[i] = j;
      }
    }
  }
  for (let i = 0; i < series.length; ++i) {
    const data = series[i].data;
    const info = stackInfo[series[i].stack];
    for (let j = 0; j < series[i].data.length; ++j) {
      // const isStart = info.stackStart[j] === i;
      const isEnd = info.stackEnd[j] === i;
      const topBorder = isEnd ? 20 : 0;
      const bottomBorder = 0;
      data[j] = {
        value: data[j],
        itemStyle: {
          borderRadius: [topBorder, topBorder, bottomBorder, bottomBorder],
        },
      };
    }
  }
  option = {
    xAxis: {
      type: "category",
      data: ["دوشنبه", "سه‌شنبه", "چهارشنبه", "پنج‌شنبه", "جمعه", "شنبه", "یک‌شنبه"],
      axisLabel: {
        color: "#9aa0ac",
      },
    },
    yAxis: {
      type: "value",
      axisLabel: {
        color: "#9aa0ac",
      },
    },
    series: series,
  };

  if (option && typeof option === "object") {
    myChart.setOption(option);
  }

  window.addEventListener("resize", myChart.resize);
}

function stackedAreaChart() {
  var dom = document.getElementById("stacked_areachart");
  var myChart = echarts.init(dom, null, {
    renderer: "canvas",
    useDirtyRect: false,
  });
  var app = {};

  var option;

  option = {
    tooltip: {
      trigger: "axis",
      axisPointer: {
        type: "cross",
        label: {
          backgroundColor: "#6a7985",
        },
      },
    },
    legend: {
      data: ["پست الکترونیک", "تبلیغات اتحادیه", "تبلیغات ویدیویی", "مستقیم", "موتور جستجو"],
      textStyle: {
        color: "#9aa0ac",
      },
    },
    toolbox: {
      feature: {
        saveAsImage: {},
      },
    },
    grid: {
      left: "3%",
      right: "4%",
      bottom: "3%",
      containLabel: true,
    },
    xAxis: [
      {
        type: "category",
        boundaryGap: false,
        data: ["دوشنبه", "سه‌شنبه", "چهارشنبه", "پنج‌شنبه", "جمعه", "شنبه", "یک‌شنبه"],
        axisLabel: {
          color: "#9aa0ac",
        },
      },
    ],
    yAxis: [
      {
        type: "value",
        axisLabel: {
          color: "#9aa0ac",
        },
      },
    ],
    series: [
      {
        name: "پست الکترونیک",
        type: "line",
        stack: "Total",
        areaStyle: {},
        emphasis: {
          focus: "series",
        },
        data: [120, 132, 101, 134, 90, 230, 210],
      },
      {
        name: "تبلیغات اتحادیه",
        type: "line",
        stack: "Total",
        areaStyle: {},
        emphasis: {
          focus: "series",
        },
        data: [220, 182, 191, 234, 290, 330, 310],
      },
      {
        name: "تبلیغات ویدیویی",
        type: "line",
        stack: "Total",
        areaStyle: {},
        emphasis: {
          focus: "series",
        },
        data: [150, 232, 201, 154, 190, 330, 410],
      },
      {
        name: "مستقیم",
        type: "line",
        stack: "Total",
        areaStyle: {},
        emphasis: {
          focus: "series",
        },
        data: [320, 332, 301, 334, 390, 330, 320],
      },
      {
        name: "موتور جستجو",
        type: "line",
        stack: "Total",
        label: {
          show: true,
          position: "top",
        },
        areaStyle: {},
        emphasis: {
          focus: "series",
        },
        data: [820, 932, 901, 934, 1290, 1330, 1320],
      },
    ],
  };

  if (option && typeof option === "object") {
    myChart.setOption(option);
  }

  window.addEventListener("resize", myChart.resize);
}
function barChartLabel() {
  var dom = document.getElementById("barChartLabel");
  var myChart = echarts.init(dom, null, {
    renderer: "canvas",
    useDirtyRect: false,
  });
  var app = {};

  var option;

  const posList = [
    "left",
    "right",
    "top",
    "bottom",
    "inside",
    "insideTop",
    "insideLeft",
    "insideRight",
    "insideBottom",
    "insideTopLeft",
    "insideTopRight",
    "insideBottomLeft",
    "insideBottomRight",
  ];
  app.configParameters = {
    rotate: {
      min: -90,
      max: 90,
    },
    align: {
      options: {
        left: "left",
        center: "center",
        right: "right",
      },
    },
    verticalAlign: {
      options: {
        top: "top",
        middle: "middle",
        bottom: "bottom",
      },
    },
    position: {
      options: posList.reduce(function (map, pos) {
        map[pos] = pos;
        return map;
      }, {}),
    },
    distance: {
      min: 0,
      max: 100,
    },
  };
  app.config = {
    rotate: 90,
    align: "left",
    verticalAlign: "middle",
    position: "insideBottom",
    distance: 15,
    onChange: function () {
      const labelOption = {
        rotate: app.config.rotate,
        align: app.config.align,
        verticalAlign: app.config.verticalAlign,
        position: app.config.position,
        distance: app.config.distance,
      };
      myChart.setOption({
        series: [
          {
            label: labelOption,
          },
          {
            label: labelOption,
          },
          {
            label: labelOption,
          },
          {
            label: labelOption,
          },
        ],
      });
    },
  };
  const labelOption = {
    show: true,
    position: app.config.position,
    distance: app.config.distance,
    align: app.config.align,
    verticalAlign: app.config.verticalAlign,
    rotate: app.config.rotate,
    formatter: "{c}  {name|{a}}",
    fontSize: 16,
    rich: {
      name: {},
    },
  };
  option = {
    tooltip: {
      trigger: "axis",
      axisPointer: {
        type: "shadow",
      },
    },
    legend: {
      data: ["جنگل", "استپ", "کویر", "زمین باتلاقی"],
      textStyle: {
        color: "#9aa0ac",
      },
    },
    xAxis: [
      {
        type: "category",
        axisTick: { show: false },
        data: ["2012", "2013", "2014", "2015", "2016"],
        axisLabel: {
          color: "#9aa0ac",
        },
      },
    ],
    yAxis: [
      {
        type: "value",
        axisLabel: {
          color: "#9aa0ac",
        },
      },
    ],
    series: [
      {
        name: "جنگل",
        type: "bar",
        barGap: 0,
        label: labelOption,
        emphasis: {
          focus: "series",
        },
        data: [320, 332, 301, 334, 390],
      },
      {
        name: "استپ",
        type: "bar",
        label: labelOption,
        emphasis: {
          focus: "series",
        },
        data: [220, 182, 191, 234, 290],
      },
      {
        name: "کویر",
        type: "bar",
        label: labelOption,
        emphasis: {
          focus: "series",
        },
        data: [150, 232, 201, 154, 190],
      },
      {
        name: "زمین باتلاقی",
        type: "bar",
        label: labelOption,
        emphasis: {
          focus: "series",
        },
        data: [98, 77, 101, 99, 40],
      },
    ],
  };

  if (option && typeof option === "object") {
    myChart.setOption(option);
  }

  window.addEventListener("resize", myChart.resize);
}
function lineChart() {
  var dom = document.getElementById("lineChart");
  var myChart = echarts.init(dom, null, {
    renderer: "canvas",
    useDirtyRect: false,
  });
  var app = {};

  var option;

  option = {
    tooltip: {
      trigger: "axis",
    },
    legend: {
      data: ["پست الکترونیک", "تبلیغات اتحادیه", "تبلیغات ویدیویی", "مستقیم", "موتور جستجو"],
      textStyle: {
        color: "#9aa0ac",
      },
    },
    grid: {
      left: "3%",
      right: "4%",
      bottom: "3%",
      containLabel: true,
    },
    xAxis: {
      type: "category",
      boundaryGap: false,
      data: ["دوشنبه", "سه‌شنبه", "چهارشنبه", "پنج‌شنبه", "جمعه", "شنبه", "یک‌شنبه"],
      axisLabel: {
        color: "#9aa0ac",
      },
    },
    yAxis: {
      type: "value",
      axisLabel: {
        color: "#9aa0ac",
      },
    },
    series: [
      {
        name: "ایمیل",
        type: "line",
        stack: "Total",
        data: [120, 132, 101, 134, 90, 230, 210],
      },
      {
        name: "تبلیغات اتحادیه",
        type: "line",
        stack: "Total",
        data: [220, 182, 191, 234, 290, 330, 310],
      },
      {
        name: "تبلیغات ویدیویی",
        type: "line",
        stack: "Total",
        data: [150, 232, 201, 154, 190, 330, 410],
      },
      {
        name: "مستقیم",
        type: "line",
        stack: "Total",
        data: [320, 332, 301, 334, 390, 330, 320],
      },
      {
        name: "موتور جستجو",
        type: "line",
        stack: "Total",
        data: [820, 932, 901, 934, 1290, 1330, 1320],
      },
    ],
  };

  if (option && typeof option === "object") {
    myChart.setOption(option);
  }

  window.addEventListener("resize", myChart.resize);
}
function pieChart() {
  var dom = document.getElementById("pieChart");
  var myChart = echarts.init(dom, null, {
    renderer: "canvas",
    useDirtyRect: false,
  });
  var app = {};

  var option;

  option = {
    title: {
      text: "مراجعه کننده یک وب سایت",
      subtext: "داده های جعلی",
      left: "center",
      textStyle: {
        color: "#9aa0ac",
      },
    },
    tooltip: {
      trigger: "item",
    },
    legend: {
      orient: "horizontal",
      bottom: "left",
      textStyle: {
        color: "#9aa0ac",
      },
    },
    series: [
      {
        name: "Access From",
        type: "pie",
        radius: "50%",
        data: [
          { value: 1048, name: "موتور جستجو" },
          { value: 735, name: "مستقیم" },
          { value: 580, name: "پست الکترونیک" },
          { value: 484, name: "تبلیغات اتحادیه" },
          { value: 300, name: "تبلیغات ویدیویی" },
        ],
        emphasis: {
          itemStyle: {
            shadowBlur: 10,
            shadowOffsetX: 0,
            shadowColor: "rgba(0, 0, 0, 0.5)",
          },
        },
      },
    ],
  };

  if (option && typeof option === "object") {
    myChart.setOption(option);
  }

  window.addEventListener("resize", myChart.resize);
}
function doughnutChart() {
  var dom = document.getElementById("doughnutChart");
  var myChart = echarts.init(dom, null, {
    renderer: "canvas",
    useDirtyRect: false,
  });
  var app = {};

  var option;

  option = {
    tooltip: {
      trigger: "item",
    },
    legend: {
      top: "5%",
      left: "center",
      textStyle: {
        color: "#9aa0ac",
      },
    },
    series: [
      {
        name: "دسترسی از",
        type: "pie",
        radius: ["40%", "70%"],
        avoidLabelOverlap: false,
        itemStyle: {
          borderRadius: 10,
          borderColor: "#fff",
          borderWidth: 2,
        },
        label: {
          show: false,
          position: "center",
        },
        emphasis: {
          label: {
            show: true,
            fontSize: 40,
            fontWeight: "bold",
          },
        },
        labelLine: {
          show: false,
        },
        data: [
          { value: 1048, name: "موتور جستجو" },
          { value: 735, name: "مستقیم" },
          { value: 580, name: "پست الکترونیک" },
          { value: 484, name: "تبلیغات اتحادیه" },
          { value: 300, name: "تبلیغات ویدیویی" },
        ],
      },
    ],
  };

  if (option && typeof option === "object") {
    myChart.setOption(option);
  }

  window.addEventListener("resize", myChart.resize);
}
function nightingaleChart() {
  var dom = document.getElementById("nightingaleChart");
  var myChart = echarts.init(dom, null, {
    renderer: "canvas",
    useDirtyRect: false,
  });
  var app = {};

  var option;

  option = {
    legend: {
      top: "bottom",
      textStyle: {
        color: "#9aa0ac",
      },
    },
    series: [
      {
        name: "نمودار بلبل",
        type: "pie",
        radius: [50, 250],
        center: ["50%", "50%"],
        roseType: "area",
        itemStyle: {
          borderRadius: 8,
        },
        data: [
          { value: 40, name: "گل سرخ 1" },
          { value: 38, name: "گل سرخ 2" },
          { value: 32, name: "گل سرخ 3" },
          { value: 30, name: "گل سرخ 4" },
          { value: 28, name: "گل سرخ 5" },
        ],
      },
    ],
  };

  if (option && typeof option === "object") {
    myChart.setOption(option);
  }

  window.addEventListener("resize", myChart.resize);
}
function candlestickChart() {
  var dom = document.getElementById("candlestickChart");
  var myChart = echarts.init(dom, null, {
    renderer: "canvas",
    useDirtyRect: false,
  });
  var app = {};

  var option;

  option = {
    xAxis: {
      data: ["2017-10-24", "2017-10-25", "2017-10-26", "2017-10-27"],
      axisLabel: {
        color: "#9aa0ac",
      },
    },
    yAxis: {
      axisLabel: {
        color: "#9aa0ac",
      },
    },
    series: [
      {
        type: "candlestick",
        data: [
          [20, 34, 10, 38],
          [40, 35, 30, 50],
          [31, 38, 33, 44],
          [38, 15, 5, 42],
          [35, 18, 6, 45],
          [40, 21, 8, 44],
        ],
      },
    ],
  };

  if (option && typeof option === "object") {
    myChart.setOption(option);
  }

  window.addEventListener("resize", myChart.resize);
}
function radarChart() {
  var dom = document.getElementById("radarChart");
  var myChart = echarts.init(dom, null, {
    renderer: "canvas",
    useDirtyRect: false,
  });
  var app = {};

  var option;

  option = {
    legend: {
      data: ["بودجه اختصاص یافته", "هزینه واقعی"],
      textStyle: {
        color: "#9aa0ac",
      },
    },
    radar: {
      // shape: 'circle',
      indicator: [
        { name: "حراجی", max: 6500 },
        { name: "مدیریت", max: 16000 },
        { name: "فناوری اطلاعات", max: 30000 },
        { name: "پشتیبانی مشتری", max: 38000 },
        { name: "توسعه", max: 52000 },
        { name: "بازار یابی", max: 25000 },
      ],
    },
    series: [
      {
        name: "بودجه در مقابل هزینه",
        type: "radar",
        data: [
          {
            value: [4200, 3000, 20000, 35000, 50000, 18000],
            name: "بودجه اختصاص یافته",
          },
          {
            value: [5000, 14000, 28000, 26000, 42000, 21000],
            name: "هزینه واقعی",
          },
        ],
      },
    ],
  };

  if (option && typeof option === "object") {
    myChart.setOption(option);
  }

  window.addEventListener("resize", myChart.resize);
}
