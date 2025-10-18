$(function () {
    $('.simpleTable').footable();
    $('.sortingTable').footable();
    $('.filterTable').footable();
    callPagination()
    callPaginationButton();
    callShowHideColumn();
});
function callPagination() {
    $('.paginationTable').footable({
        "paging": {
            "enabled": true
        },
        "columns": [{
            "name": "id",
            "title": "شناسه",
            "breakpoints": "xs sm",
            "type": "number",
            "style": {
                "width": 80,
                "maxWidth": 80
            }
        },
        {
            "name": "firstName",
            "title": "نام کوچک"
        },
        {
            "name": "lastName",
            "title": "نام خانوادگی"
        },
        {
            "name": "something",
            "title": "هرگز دیده نشده اما همیشه در اطراف",
            "visible": false,
            "filterable": false
        },
        {
            "name": "jobTitle",
            "title": "عنوان کار",
            "breakpoints": "xs sm",
            "style": {
                "maxWidth": 200,
                "overflow": "hidden",
                "textOverflow": "ellipsis",
                "wordBreak": "keep-all",
                "whiteSpace": "nowrap"
            }
        },
        {
            "name": "started",
            "title": "شروع کردن",
            "type": "date",
            "breakpoints": "xs sm md",
            "formatString": "MMM YYYY"
        },
        {
            "name": "dob",
            "title": "تاریخ تولد",
            "type": "date",
            "breakpoints": "xs sm md",
            "formatString": "DD MMM YYYY"
        },
        {
            "name": "status",
            "title": "وضعیت"
        }
        ],
        "rows": [
            { "id": 1, "firstName": "عیاشی", "lastName": "محمدی", "something": 1381105566987, "jobTitle": "سرنشین اتاق لباس", "started": 1367700388909, "dob": 122365714987, "status": "غیر فعال" },
            { "id": 2, "firstName": "نیلی", "lastName": "محمدی", "something": 1267237540208, "jobTitle": "مهندس تعمیر و نگهداری", "started": 1382739570973, "dob": 183768652128, "status": "معلق" },
            { "id": 3, "firstName": "لورین", "lastName": "محمدی", "something": 1263216405811, "jobTitle": "متخصص ژئو فیزیک", "started": 1265199486212, "dob": 414197000409, "status": "فعال" },
            { "id": 4, "firstName": "مایر", "lastName": "محمدی", "something": 1317652005631, "jobTitle": "صندوق بازی قفس بازی", "started": 1359190254082, "dob": 381574699574, "status": "معلق" },
            { "id": 5, "firstName": "ناله", "lastName": "محمدی", "something": 1297738568550, "jobTitle": "کتابدار دبیرستانی", "started": 1377538533615, "dob": -11216050657, "status": "فعال" },
            { "id": 6, "firstName": "نیکیا", "lastName": "محمدی", "something": 1283192889859, "jobTitle": "دلقک", "started": 1348067291754, "dob": -236655382175, "status": "فعال" },
            { "id": 7, "firstName": "رین", "lastName": "محمدی", "something": 1289586239969, "jobTitle": "توزیع کننده بلیط کار", "started": 1312738712940, "dob": 483475202947, "status": "معلق" },
            { "id": 8, "firstName": "رحیم", "lastName": "محمدی", "something": 1351969871214, "jobTitle": "مهندس", "started": 1300981406722, "dob": 267565804332, "status": "معلق" },
            { "id": 9, "firstName": "سپانی", "lastName": "محمدی", "something": 1318107009703, "jobTitle": "جمع کننده حساب", "started": 1348566414201, "dob": 84698632860, "status": "غیر فعال" },
            { "id": 10, "firstName": "لوری", "lastName": "محمدی", "something": 1298847936600, "jobTitle": "وام دهنده تجاری", "started": 1306984494872, "dob": 647549298565, "status": "معلق" },
            { "id": 11, "firstName": "ماریا", "lastName": "محمدی", "something": 1372447291002, "jobTitle": "جزئیات", "started": 1295239832657, "dob": 92796339552, "status": "غیر فعال" },
            { "id": 12, "firstName": "دریاچه", "lastName": "محمدی", "something": 1296451003728, "jobTitle": "پوشاک پوش", "started": 1350695946669, "dob": 6068444160, "status": "غیر فعال" },
            { "id": 13, "firstName": "ایزیدرا", "lastName": "محمدی", "something": 1285852466255, "jobTitle": "خط کش", "started": 1264658548150, "dob": 129659544744, "status": "فعال" },
            { "id": 14, "firstName": "مارکی", "lastName": "محمدی", "something": 1336968147859, "jobTitle": "مهندس تعمیر و نگهداری", "started": 1281348596711, "dob": 69513590957, "status": "معلق" },
            { "id": 15, "firstName": "جو", "lastName": "محمدی", "something": 1322560108993, "jobTitle": "مهندس تعمیر و نگهداری", "started": 1350354712910, "dob": 397465403667, "status": "فعال" },
            { "id": 16, "firstName": "دلهره", "lastName": "محمدی", "something": 1367925208609, "jobTitle": "کتابدار دبیرستانی", "started": 1360754556666, "dob": -101355021375, "status": "معلق" },
            { "id": 17, "firstName": "آناماریا", "lastName": "محمدی", "something": 1385602980951, "jobTitle": "ظ", "started": 1267426062440, "dob": 129358493928, "status": "فعال" },
            { "id": 18, "firstName": "جون", "lastName": "محمدی", "something": 1270540402378, "jobTitle": "اسکیت باز", "started": 1343534987824, "dob": 405467757390, "status": "غیر فعال" }
            ]
    });
}

function callPaginationButton() {
    $('[data-page-size]').on('click', function (e) {
        e.preventDefault();
        var newSize = $(this).data('pageSize');
        FooTable.get('#paginationBtn').pageSize(newSize);
    });
    $('#paginationBtn').footable();
}

function callShowHideColumn(){
	$('#hidecolumn').footable({
		"expandFirst": true,
		"columns": [
			{ "name": "id", "visible": false },
			{ "name": "firstName", "title": "نام کوچک" },
			{ "name": "lastName", "title": "نام خانوادگی" },
			{ "name": "jobTitle", "title": "عنوان کار", "breakpoints": "xs" },
			{ "name": "started", "title": "شروع کردن", "breakpoints": "xs sm" },
			{ "name": "dob", "title": "تاریخ تولد", "breakpoints": "all" }
			],
			"rows": [
				{ "id": 1, "firstName": "دنیس", "lastName": "قصبه", "jobTitle": "معلم تاریخ دبیرستان", "started": "پنج شنبه - ۱ فروردین ۱۴۰۳", "dob": "۱۴۰5/۰۱/۱۶" },
				{ "id": 2, "firstName": "الودیا", "lastName": "ویز", "jobTitle": "یاور کاغذ دیواری", "started": "پنج شنبه - ۱ فروردین ۱۴۰۳", "dob": "۱۴۰5/۰۱/۱۶" },
				{ "id": 3, "firstName": "رگ", "lastName": "هانر", "jobTitle": "پزشک متخصص پرستار داخلی", "started": "پنج شنبه - ۱ فروردین ۱۴۰۳", "dob": "۱۴۰5/۰۱/۱۶" },
				{ "id": 4, "firstName": "جون", "lastName": "لندا", "jobTitle": "مأمور", "started": "پنج شنبه - ۱ فروردین ۱۴۰۳", "dob": "۱۴۰5/۰۱/۱۶" },
				{ "id": 5, "firstName": "سلیمان", "lastName": "چلیکر", "jobTitle": "اسکیت باز", "started": "پنج شنبه - ۱ فروردین ۱۴۰۳", "dob": "۱۴۰5/۰۱/۱۶" },
				{ "id": 6, "firstName": "بار", "lastName": "لوئیس", "jobTitle": "دلقک", "started": "پنج شنبه - ۱ فروردین ۱۴۰۳", "dob": "۱۴۰5/۰۱/۱۶" },
				{ "id": 7, "firstName": "اره", "lastName": "نشت", "jobTitle": "کشتی های مأمور جنگ الکترونیکی", "started": "پنج شنبه - ۱ فروردین ۱۴۰۳", "dob": "۱۴۰5/۰۱/۱۶" },
				{ "id": 8, "firstName": "لوریان", "lastName": "خندق", "jobTitle": "کتابدار خدمات فنی", "started": "پنج شنبه - ۱ فروردین ۱۴۰۳", "dob": "A۱۴۰5/۰۱/۱۶" }
				]
	});
}
