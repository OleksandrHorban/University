<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Друга сторінка</title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/css/bootstrap.min.css">
</head>
<body>
    <div class="d-flex flex-column flex-md-row align-items-center p-3 px-md-4 mb-3 bg-white border-bottom shadow-sm">
        <h5 class="my-0 mr-md-auto font-weight-normal">Магазин меблів</h5>
    </div>
    <h3>ВАШЕ ЗАМОВЛЕННЯ ПРИЙНЯТО</h3>
    <?php
    if(isset($_POST['type'])){
        $select1 = $_POST['type'];
        switch ($select1) {
            case 'shafa':
                echo 'Замовлено виріб - Шафа<br/>';
                break;
            case 'table':
                echo 'Замовлено виріб - Стіл<br/>';
                break;
            case 'chest':
                echo 'Замовлено виріб - Стілець<br/>';
                break;
            case 'servant':
                echo 'Замовлено виріб - Сервант<br/>';
                break;
            default:
                # code...
                break;
        }
    }
    if(isset($_POST['material'])){
        $select1 = $_POST['material'];
        switch ($select1) {
            case 'dub':
                echo 'Матеріал - Дуб<br/>';
                break;
            case 'klen':
                echo 'Матеріал - Клен<br/>';
                break;
            case 'buk':
                echo 'Матеріал - Бук<br/>';
                break;
            case 'gorih':
                echo 'Матеріал - Горіх<br/>';
                break;
            default:
                # code...
                break;
        }
    }
    $kilkist = $_POST['count'];
    echo "В кількості - $kilkist"
    ?>
    <p>
        <a href="09-JS01-0.html">Повернення</a>
</body>
</html>