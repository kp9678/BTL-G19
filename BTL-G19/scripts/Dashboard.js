
document.addEventListener("DOMContentLoaded", function () {
/*BIỂU ĐỒ CỘT - HỌC VIÊN THEO KHÓA HỌC*/
    const barCanvas = document.getElementById("mainBarChart");

    if (barCanvas) {

        new Chart(barCanvas, {

            type: "bar",

            data: {

                labels: barLabels,

                datasets: [{

                    label: "Số học viên",

                    data: barData,

                    backgroundColor: [

                        "#3B82F6",
                        "#10B981",
                        "#F59E0B",
                        "#EF4444",
                        "#8B5CF6",
                        "#06B6D4",
                        "#F97316",
                        "#6366F1",
                        "#84CC16",
                        "#EC4899"

                    ],

                    borderRadius: 8

                }]

            },

            options: {

                responsive: true,

                maintainAspectRatio: false,

                plugins: {

                    legend: {

                        display: false

                    },

                    title: {

                        display: true,

                        text: "SỐ HỌC VIÊN THEO KHÓA HỌC",

                        font: {

                            size: 16

                        }

                    }

                },

                scales: {

                    y: {

                        beginAtZero: true,

                        ticks: {

                            stepSize: 1

                        }

                    }

                }

            }

        });

    }

/*BIỂU ĐỒ TRÒN - TRẠNG THÁI KHÓA HỌC*/
    const pieCanvas = document.getElementById("mainPieChart");

    if (pieCanvas) {

        new Chart(pieCanvas, {

            type: "doughnut",

            data: {

                labels: pieLabels,

                datasets: [{

                    data: pieData,

                    backgroundColor: [

                        "#10B981",

                        "#EF4444"

                    ],

                    borderWidth: 2

                }]

            },

            options: {

                responsive: true,

                maintainAspectRatio: false,

                cutout: "55%",

                plugins: {

                    title: {

                        display: true,

                        text: "TRẠNG THÁI KHÓA HỌC",

                        font: {

                            size: 16

                        }

                    },

                    legend: {

                        position: "bottom"

                    }

                }

            }

        });

    }
    /* BIỂU ĐỒ ĐƯỜNG - HỌC VIÊN THEO LỚP*/

    const lineCanvas = document.getElementById("sideLineChart");

    if (lineCanvas) {

        new Chart(lineCanvas, {

            type: "line",

            data: {

                labels: lineLabels,

                datasets: [{

                    label: "Số học viên",

                    data: lineData,

                    borderColor: "#2563EB",

                    backgroundColor: "rgba(37,99,235,0.15)",

                    fill: true,

                    tension: 0.35,

                    pointRadius: 5,

                    pointHoverRadius: 8

                }]

            },

            options: {

                responsive: true,

                maintainAspectRatio: false,

                plugins: {

                    legend: {

                        display: false

                    },

                    title: {

                        display: true,

                        text: "SỐ HỌC VIÊN THEO LỚP",

                        font: {

                            size: 16

                        }

                    }

                },

                scales: {

                    y: {

                        beginAtZero: true,

                        ticks: {

                            stepSize: 1

                        }

                    }

                }

            }

        });

    }

});