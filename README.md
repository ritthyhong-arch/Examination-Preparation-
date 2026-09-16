# Examination-Preparation-
ប្រព័ន្ធគ្រប់គ្រងការប្រឡងសិស្ស (School Examination Management System)

ប្រព័ន្ធគ្រប់គ្រងការប្រឡង គាំទ្រការរៀបចំបន្ទប់ប្រឡងស្វ័យប្រវត្តិ វត្តមាន ការបញ្ចូលពិន្ទុ លទ្ធផលជាប់/ធ្លាក់ ចំណាត់ថ្នាក់ជ័យលាភី Top 3 ព្រមទាំងការបោះពុម្ពទម្រង់ក្រដាស A4 ស្តង់ដារក្រសួងអប់រំ យុវជន និងកីឡា។

## ការរៀបចំ Supabase Cloud Database (Setup Supabase)

១. ចុះឈ្មោះគណនីឥតគិតថ្លៃនៅ https://supabase.com រួចបង្កើតគម្រោងថ្មី (New Project)
២. ចូលទៅកាន់ SQL Editor ក្នុង Supabase រួច Run កូដខាងក្រោមដើម្បីបង្កើតតារាង៖

```sql
create table if not exists exam_candidates (
    exam_key text primary key,
    data jsonb not null default '[]'::jsonb,
    updated_at timestamp with time zone default now()
);

alter table exam_candidates enable row level security;
create policy "Allow public read" on exam_candidates for select using (true);
create policy "Allow public insert" on exam_candidates for insert with check (true);
create policy "Allow public update" on exam_candidates for update using (true);
```

៣. ចូលទៅកាន់ Project Settings -> API ដើម្បីចម្លងយក Project URL និង Anon (public) Key
៤. បើកកម្មវិធី ហើយចុចលើប៊ូតុង «Supabase Cloud» នៅលើរបារខាងលើ រួច Paste ចូលជាការស្រេច!

## ការដាក់ឱ្យដំណើរការលើ GitHub Pages (Deploy to GitHub Pages)

១. ចូលទៅកាន់ Repository របស់អ្នកនៅលើ GitHub
២. ចុចលើ Settings -> ជ្រើសរើស Pages នៅខាងឆ្វេង
៣. នៅត្រង់ Branch ជ្រើសរើស main និង Folder / (root) រួចចុច Save
៤. រង់ចាំប្រហែល ១ នាទី លោកអ្នកនឹងទទួលបាន Link គេហទំព័រផ្ទាល់ខ្លួន៖
   https://ritthyhong-arch.github.io/Examination-Preparation-/
